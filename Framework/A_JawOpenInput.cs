using UnityEngine;
using ViveSR;
using ViveSR.anipal.Lip;
using System.Collections.Generic; // Dictionary型の名前空間を追加

public class A_JawOpenInput : MonoBehaviour
{
    public SharedData sharedData;

    public void Initialize()
    {
        // 必要な初期化処理
        Debug.Log("初期化");
    }

    public void Main()
    {
        // Jaw Openデータを取得
        if (SRanipal_Lip.GetLipWeightings(out Dictionary<LipShape, float> lipWeightings))
        {
            float jawOpen = 0.0f;
            if (lipWeightings.ContainsKey(LipShape.Jaw_Open))
            {
                jawOpen = lipWeightings[LipShape.Jaw_Open];
            }

            // データを保存
            float[] newData = new float[10]; // 10次元のデータ
            newData[1] = jawOpen; // Jaw Openの値を2番目の要素に保存
            for (int i = 0; i < 10; i++)
            {
                if (i != 1) newData[i] = float.NaN; // 他の要素をNaNに設定
            }

            sharedData.SaveInputData(newData);

            Debug.Log($"A段階: Jaw Openデータ取得 - {jawOpen}");
        }
        else
        {
            Debug.LogWarning("A段階: Jaw Openデータ取得に失敗しました。");
        }
    }
}
