using UnityEngine;

public class TestLightIntensity : MonoBehaviour
{
    public Light directionalLight;

    void Update()
    {
        if (directionalLight != null)
        {
            directionalLight.intensity = Mathf.PingPong(Time.time, 1.0f); // 0 ～ 1 の間で明るさを変化
        }
    }
}