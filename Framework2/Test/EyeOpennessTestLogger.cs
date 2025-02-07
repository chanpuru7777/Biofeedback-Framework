using System.IO;
using UnityEngine;

public class EyeOpennessTestLogger : MonoBehaviour
{
    public SharedData sharedData; // データ共有スクリプト
    public string csvFilePath = "TestDataLog_EyeOpenness.csv"; // 保存先のCSVファイル名

    private StreamWriter writer; // ファイル書き込み用

    void Start()
    {
        // CSVファイルのヘッダーを作成
        writer = new StreamWriter(csvFilePath, false); // 上書きモードでファイルを開く
        writer.WriteLine("Frame,Time,A_Level,B_Level"); // ヘッダー行
        Debug.Log($"データログを開始しました: {csvFilePath}");
    }

    void Update()
    {
        // データが存在する場合のみ処理
        if (sharedData.inputDataA.Count > 0 && sharedData.processedDataB.Count > 0)
        {
            // 最新のデータを取得
            int frame = Time.frameCount;
            float timestamp = sharedData.timestampsA[sharedData.timestampsA.Count - 1];
            float eyeOpenness = sharedData.inputDataA[sharedData.inputDataA.Count - 1][0]; // 瞼の開き具合（A_Level）
            float awarenessLevel = sharedData.processedDataB[sharedData.processedDataB.Count - 1][0]; // 処理後データ（B_Level）

            // データをCSVファイルに書き込む
            writer.WriteLine($"{frame},{timestamp},{eyeOpenness},{awarenessLevel}");
        }
    }

    void OnDestroy()
    {
        // ファイルを閉じる
        if (writer != null)
        {
            writer.Close();
            Debug.Log($"データログを終了しました: {csvFilePath}");
        }
    }
}
