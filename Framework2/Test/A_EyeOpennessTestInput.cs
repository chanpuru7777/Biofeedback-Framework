using System.IO;
using System.Linq;
using UnityEngine;

public class A_EyeOpennessTestInput : MonoBehaviour
{
    public SharedData sharedData; // データ保存スクリプト
    private string csvFilePath = "Assets/Script/Framework2/Test/A_EyeOpenness_ran.csv"; // CSVファイルの絶対パス
    private float[] testData; // テストデータを格納する配列
    private int currentIndex = 0; // 現在のデータインデックス
    private int totalDataPoints; // 全データポイント数

    public void Initialize()
    {
        // CSVファイルを読み込み、データを配列に変換
        if (!File.Exists(csvFilePath))
        {
            Debug.LogError($"CSVファイルが見つかりません: {csvFilePath}");
            return;
        }

        try
        {
            Debug.Log($"CSVファイルを読み込み中: {csvFilePath}");
            var lines = File.ReadAllLines(csvFilePath);

            // 最初の行（ヘッダー行）をスキップし、残りを数値に変換
            testData = lines
                .Skip(1) // ヘッダー行をスキップ
                .Where(line => !string.IsNullOrWhiteSpace(line)) // 空白行を除外
                .Select(line =>
                {
                    if (float.TryParse(line, out float result))
                    {
                        return result; // 正常な数値の場合は変換
                    }
                    else
                    {
                        Debug.LogWarning($"不正なデータをスキップ: {line}");
                        return float.NaN; // NaNとして処理
                    }
                })
                .Where(value => !float.IsNaN(value)) // NaNを除外
                .ToArray();

            totalDataPoints = testData.Length;
            Debug.Log($"CSVファイル読み込み成功。データポイント数: {totalDataPoints}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"CSV読み込みエラー: {ex.Message}");
        }
    }

    public void Main()
    {
        if (testData == null || totalDataPoints == 0)
        {
            Debug.LogWarning("テストデータがロードされていません。Initializeメソッドを確認してください。");
            return;
        }

        if (currentIndex >= totalDataPoints)
        {
            Debug.Log("すべてのテストデータが処理されました。");
            return;
        }

        // 現在のインデックスのデータを取得
        float eyeOpenness = testData[currentIndex++];

        // データを保存
        float[] newData = new float[10]; // 10次元のデータ
        newData[0] = eyeOpenness;
        for (int i = 1; i < 10; i++) newData[i] = float.NaN;

        sharedData.SaveInputData(newData);

        Debug.Log($"A段階: 瞼の開き具合テストデータ取得 - {eyeOpenness}");
    }
}
