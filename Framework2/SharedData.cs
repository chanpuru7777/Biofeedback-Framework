using System.Collections.Generic;
using UnityEngine;

public class SharedData : MonoBehaviour
{
    public List<float[]> inputDataA = new List<float[]>(); // A段階のデータ（入力）
    public List<float> timestampsA = new List<float>();   // A段階データのタイムスタンプ
    public List<float[]> processedDataB = new List<float[]>(); // B段階のデータ（処理後）
    public List<float> timestampsB = new List<float>();   // B段階データのタイムスタンプ

    // A段階のデータを保存
    public void SaveInputData(float[] data)
    {
        inputDataA.Add(data);
        timestampsA.Add(Time.time);
    }

    // B段階のデータを保存
    public void SaveProcessedData(float[] data)
    {
        processedDataB.Add(data);
        timestampsB.Add(Time.time);
    }
}
