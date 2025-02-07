using UnityEngine;

public class B_JawOpenAwareness : MonoBehaviour
{
    public SharedData sharedData;

    public void Initialize()
    {
        Debug.Log("B_JawOpenAwareness: 初期化完了");
    }

    public void Main()
    {
        if (sharedData.inputDataA.Count >= 1)
        {
            float[] currentData = sharedData.inputDataA[sharedData.inputDataA.Count - 1];

            // 口の開き具合を取得（currentData[1]）
            float jawOpen = currentData[1];

            // レベル計算（簡略化した例）
            int awarenessLevel = CalculateJawOpenLevel(jawOpen);

            // データ保存
            float[] newProcessedData = new float[3];
            newProcessedData[0] = awarenessLevel; // 環境光の明るさレベル
            newProcessedData[1] = awarenessLevel; // コントローラ振動の強さレベル
            newProcessedData[2] = 1;             // データ有効フラグ
            sharedData.SaveProcessedData(newProcessedData);

            //Debug.Log($"B段階: Jaw Openのレベル推定 - レベル {awarenessLevel}");
        }
        else
        {
            Debug.Log("入力データが不足しているため、処理をスキップしました");
        }
    }

    private int CalculateJawOpenLevel(float jawOpen)
    {
        // Jaw Openの値に基づいてレベルを計算
        if (jawOpen < 0.2f) return 1; // 閉じている
        if (jawOpen < 0.5f) return 2; // 少し開いている
        if (jawOpen < 0.8f) return 3; // 開いている
        return 4;                      // 大きく開いている
    }
}
