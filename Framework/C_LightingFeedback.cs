using UnityEngine;
/// <summary>
/// /////////////////////////////////////////////////////////////
/// </summary>
public class C_LightingFeedback : MonoBehaviour
{
    public SharedData sharedData;
    public Light directionalLight;

    private float[] lightLevels = { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };

    public void Initialize()
    {
        // 必要な初期化処理
    }

    public void Main()
    {
        if (sharedData.processedDataB.Count > 0)
        {
            float[] latestData = sharedData.processedDataB[sharedData.processedDataB.Count - 1];
            int awarenessLevel = (int)latestData[0];

            if (directionalLight != null)
            {
                directionalLight.intensity = lightLevels[awarenessLevel];
                //Debug.Log($"C段階（光）: 環境光調整 - レベル {awarenessLevel}, 強度 {lightLevels[awarenessLevel]}");
            }
            RenderSettings.ambientIntensity = lightLevels[awarenessLevel];
        }
    }
}
