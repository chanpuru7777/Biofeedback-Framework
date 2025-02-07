using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    public MonoBehaviour Astage;       // A段階モジュール（汎用型）
    public MonoBehaviour Bstage;       // B段階モジュール（汎用型）
    public MonoBehaviour Cstage;       // C段階モジュール（汎用型）

    void Start()
    {
        // A段階モジュールの初期化
        if (Astage != null)
        {
            if (Astage is A_EyeOpennessInput eyeOpennessInput)
            {
                eyeOpennessInput.Initialize();
            }
            else if (Astage is A_JawOpenInput jawOpenInput)
            {
                jawOpenInput.Initialize();
            }
            else if (Astage is A_ControllerPositionInput controllerPositionInput)
            {
                controllerPositionInput.Initialize();
            }
            else if (Astage is A_JawOpenTestInput jawOpenTestInput)
            {
                jawOpenTestInput.Initialize();
            }
            else if (Astage is A_ControllerHeightTestInput controllerHeightTestInput)
            {
                controllerHeightTestInput.Initialize();
            }
            else if (Astage is A_EyeOpennessTestInput eyeOpennessTestInput) // A_EyeOpennessTestInput を追加
            {
                eyeOpennessTestInput.Initialize();
            }
        }

        // B段階モジュールの初期化
        if (Bstage != null)
        {
            if (Bstage is B_BlinkAwareness blinkAwareness)
            {
                blinkAwareness.Initialize();
            }
            else if (Bstage is B_JawOpenAwareness jawOpenAwareness)
            {
                jawOpenAwareness.Initialize();
            }
            else if (Bstage is B_ControllerHeightAwareness controllerHeightAwareness)
            {
                controllerHeightAwareness.Initialize();
            }
        }

        // C段階モジュールの初期化
        if (Cstage != null)
        {
            if (Cstage is C_LightingFeedback lightingFeedback)
            {
                lightingFeedback.Initialize();
            }
            else if (Cstage is C_ControllerVibrationFeedback vibrationFeedback)
            {
                vibrationFeedback.Initialize();
            }
        }
    }

    void Update()
    {
        // A段階モジュールのメイン処理
        if (Astage != null)
        {
            if (Astage is A_EyeOpennessInput eyeOpennessInput)
            {
                eyeOpennessInput.Main();
            }
            else if (Astage is A_JawOpenInput jawOpenInput)
            {
                jawOpenInput.Main();
            }
            else if (Astage is A_ControllerPositionInput controllerPositionInput)
            {
                controllerPositionInput.Main();
            }
            else if (Astage is A_JawOpenTestInput jawOpenTestInput)
            {
                jawOpenTestInput.Main();
            }
            else if (Astage is A_ControllerHeightTestInput controllerHeightTestInput)
            {
                controllerHeightTestInput.Main();
            }
            else if (Astage is A_EyeOpennessTestInput eyeOpennessTestInput) // A_EyeOpennessTestInput のメイン処理を追加
            {
                eyeOpennessTestInput.Main();
            }
        }

        // B段階モジュールのメイン処理
        if (Bstage != null)
        {
            if (Bstage is B_BlinkAwareness blinkAwareness)
            {
                blinkAwareness.Main();
            }
            else if (Bstage is B_JawOpenAwareness jawOpenAwareness)
            {
                jawOpenAwareness.Main();
            }
            else if (Bstage is B_ControllerHeightAwareness controllerHeightAwareness)
            {
                controllerHeightAwareness.Main();
            }
        }

        // C段階モジュールのメイン処理
        if (Cstage != null)
        {
            if (Cstage is C_LightingFeedback lightingFeedback)
            {
                lightingFeedback.Main();
            }
            else if (Cstage is C_ControllerVibrationFeedback vibrationFeedback)
            {
                vibrationFeedback.Main();
            }
        }
    }
}
