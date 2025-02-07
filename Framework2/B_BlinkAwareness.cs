using UnityEngine;
using System.Collections.Generic;

public class B_BlinkAwareness : MonoBehaviour
{
    public SharedData sharedData;

    private bool isBlinking = false;
    private bool isClosing = false;

    private float blinkStartTime;
    private float blinkAmplitude;
    private float blinkDuration;
    private float blinkPeak;
    private float blinkStart;

    public List<float> nonVoluntaryBlinkTimestamps = new List<float>();

    public void Initialize()
    {
        isBlinking = false;
        isClosing = false;
        nonVoluntaryBlinkTimestamps.Clear();
    }

    public void Main()
    {
        if (sharedData.inputDataA.Count >= 2)
        {
            float[] currentData = sharedData.inputDataA[sharedData.inputDataA.Count - 1];
            float[] previousData = sharedData.inputDataA[sharedData.inputDataA.Count - 2];

            float currentBlink = currentData[0];
            float previousBlink = previousData[0];

            DetectNonVoluntaryBlink(currentBlink, previousBlink);
            CleanOldTimestamps();

            int awarenessLevel = CalculateAwarenessLevel();

            float[] newProcessedData = new float[3];
            newProcessedData[0] = awarenessLevel;
            newProcessedData[1] = awarenessLevel;
            newProcessedData[2] = 1;
            sharedData.SaveProcessedData(newProcessedData);

            Debug.Log($"B段階: 覚醒度推定 - レベル {awarenessLevel}, 瞬目頻度（60秒あたり）: {nonVoluntaryBlinkTimestamps.Count}");
        }
        else
        {
            Debug.Log("入力データが不足しているため、処理をスキップしました");
        }
    }

    private void DetectNonVoluntaryBlink(float currentBlink, float previousBlink)
    {
        if (!isBlinking && currentBlink < previousBlink)
        {
            isBlinking = true;
            isClosing = true;
            blinkStartTime = Time.time;
            blinkStart = currentBlink;
            blinkPeak = currentBlink;
        }
        else if (isBlinking)
        {
            if (isClosing)
            {
                if (currentBlink < blinkPeak)
                {
                    blinkPeak = currentBlink;
                }
                else if (currentBlink > blinkPeak)
                {
                    isClosing = false;
                    blinkAmplitude = blinkStart - blinkPeak;
                }
            }
            else
            {
                if (currentBlink >= 1.0f || currentBlink < previousBlink)
                {
                    blinkDuration = (Time.time - blinkStartTime) * 1000;

                    if (blinkAmplitude > 0.2 && blinkAmplitude <= 0.8 && blinkDuration <= 300)
                    {
                        nonVoluntaryBlinkTimestamps.Add(Time.time);
                    }

                    isBlinking = false;
                }
            }
        }
    }

    private void CleanOldTimestamps()
    {
        float currentTime = Time.time;
        nonVoluntaryBlinkTimestamps.RemoveAll(timestamp => currentTime - timestamp > 60f);
    }

    private int CalculateAwarenessLevel()
    {
        float currentTime = Time.time;
        if (currentTime <= 60f)
        {
            float frequencyPerMinute = nonVoluntaryBlinkTimestamps.Count * (60f / currentTime);
            return CalculateLevelFromFrequency(frequencyPerMinute);
        }
        else
        {
            return CalculateLevelFromFrequency(nonVoluntaryBlinkTimestamps.Count);
        }
    }

    private int CalculateLevelFromFrequency(float frequency)
    {
        if (frequency <= 5) return 1;
        if (frequency <= 10) return 2;
        if (frequency <= 15) return 3;
        if (frequency <= 20) return 4;
        return 0;
    }
}
