using UnityEngine;
using ViveSR.anipal.Eye;

public class A_EyeOpennessInput : MonoBehaviour
{
    public SharedData sharedData;

    public void Initialize()
    {
        // 必要な初期化処理
        Debug.Log("初期化");
    }

    public void Main()
    {
        EyeData eyeData = new EyeData();
        if (SRanipal_Eye_API.GetEyeData(ref eyeData) == ViveSR.Error.WORK)
        {
            float eyeOpenness;
            SRanipal_Eye.GetEyeOpenness(EyeIndex.LEFT, out eyeOpenness);

            // データを保存
            float[] newData = new float[10]; // 10次元のデータ
            newData[0] = eyeOpenness;
            for (int i = 1; i < 10; i++) newData[i] = float.NaN;

            sharedData.SaveInputData(newData);

            Debug.Log($"A段階: 瞼の開き具合データ取得 - {eyeOpenness}");
        }
    }
}
