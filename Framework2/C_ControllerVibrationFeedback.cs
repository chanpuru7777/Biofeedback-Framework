using UnityEngine;
using Valve.VR;

public class C_ControllerVibrationFeedback : MonoBehaviour
{
    public SharedData sharedData;

    private SteamVR_Action_Vibration vibration = SteamVR_Actions.default_Haptic;
    private float[] vibrationLevels = { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };

    public void Initialize()
    {
        // 必要な初期化処理
    }

    public void Main()
    {
        if (sharedData.processedDataB.Count > 0)
        {
            float[] latestData = sharedData.processedDataB[sharedData.processedDataB.Count - 1];
            int awarenessLevel = Mathf.Clamp((int)latestData[1], 0, vibrationLevels.Length - 1);

            if (vibrationLevels[awarenessLevel] > 0)
            {
                // 振動を実行（左右のコントローラ）
                vibration.Execute(0, 0.2f, 100, vibrationLevels[awarenessLevel], SteamVR_Input_Sources.LeftHand);
                vibration.Execute(0, 0.2f, 100, vibrationLevels[awarenessLevel], SteamVR_Input_Sources.RightHand);
                //Debug.Log($"C段階（振動）: コントローラ振動調整 - レベル {awarenessLevel}, 強さ {vibrationLevels[awarenessLevel]}");
            }
        }
    }
}
