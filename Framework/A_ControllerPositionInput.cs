using UnityEngine;
using Valve.VR;

public class A_ControllerPositionInput : MonoBehaviour
{
    public SharedData sharedData; // データ保存スクリプト
    public SteamVR_Action_Pose poseAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand; // デフォルトで右手コントローラ

    public void Initialize()
    {
        Debug.Log("A_ControllerPositionInput: 初期化完了");
    }

    public void Main()
    {
        if (poseAction != null && poseAction[inputSource].active)
        {
            // コントローラの位置を取得
            Vector3 position = poseAction[inputSource].localPosition;

            // データを保存（3次元の座標を保存）
            float[] newData = new float[10]; // 10次元のデータ
            newData[2] = position.x; // X座標を[2]に保存
            newData[3] = position.y; // Y座標を[3]に保存
            newData[4] = position.z; // Z座標を[4]に保存

            // 他の要素はNaNに設定
            for (int i = 0; i < 10; i++)
            {
                if (i < 2 || i > 4) newData[i] = float.NaN;
            }

            sharedData.SaveInputData(newData);

            Debug.Log($"A段階: コントローラ位置データ取得 - X: {position.x}, Y: {position.y}, Z: {position.z}");
        }
        else
        {
            Debug.LogWarning("A段階: コントローラの位置データが取得できません");
        }
    }
}
