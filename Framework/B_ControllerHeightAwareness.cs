using UnityEngine;

public class B_ControllerHeightAwareness : MonoBehaviour
{
    public SharedData sharedData;

    private float initialHeight; // 初期の高さ
    private bool isInitialized = false; // 初期化完了フラグ

    public void Initialize()
    {
        Debug.Log("B_ControllerHeightAwareness: 初期化完了");
    }

    public void Main()
    {
        if (!isInitialized)
        {
            // 初期の高さを記録
            if (sharedData.inputDataA.Count >= 1)
            {
                float[] currentData = sharedData.inputDataA[sharedData.inputDataA.Count - 1];
                initialHeight = currentData[3]; // y座標は[3]に保存されている
                isInitialized = true;
                Debug.Log($"B_ControllerHeightAwareness: 初期高さを記録 - {initialHeight}");
            }
            else
            {
                Debug.LogWarning("B_ControllerHeightAwareness: 初期化時に入力データが不足しています");
                return; // 初期化できるまで処理をスキップ
            }
        }

        if (sharedData.inputDataA.Count >= 1)
        {
            // 現在のy座標を取得
            float[] currentData = sharedData.inputDataA[sharedData.inputDataA.Count - 1];
            float currentHeight = currentData[3]; // y座標は[3]に保存されている

            // レベルを計算
            int level = CalculateHeightLevel(currentHeight);

            // データを保存
            float[] newProcessedData = new float[3];
            newProcessedData[0] = level; // レベルを保存
            newProcessedData[1] = level; // データ有効フラグとしても利用
            newProcessedData[2] = 1;     // 有効フラグ
            sharedData.SaveProcessedData(newProcessedData);

            Debug.Log($"B段階: 高さレベル計算 - 現在の高さ: {currentHeight}, レベル: {level}");
        }
        else
        {
            Debug.LogWarning("B_ControllerHeightAwareness: 入力データが不足しています");
        }
    }

    private int CalculateHeightLevel(float currentHeight)
    {
        float difference = initialHeight - currentHeight;

        // レベルの計算（差が大きいほど高いレベル）
        if (difference < -0.2f) return 0; // 高い位置
        if (difference < -0.1f) return 1; // 少し高い位置
        if (difference < 0.1f) return 2;  // 基準付近
        if (difference < 0.2f) return 3;  // 少し低い位置
    }
}
