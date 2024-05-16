using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    
    public static CameraShake Instanse { get; private set; }
    
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;
    
    private void Awake()
    {
        _virtualCameraNoise = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        Instanse = this;
    }

    public void ShakeCamera(float amplitude, float frequency, float duration)
    {
        _virtualCameraNoise.m_AmplitudeGain = amplitude;
        _virtualCameraNoise.m_FrequencyGain = frequency;
        StartCoroutine(StopShake(duration, amplitude));
    }

    private IEnumerator StopShake(float duration, float amplitude)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;
            _virtualCameraNoise.m_AmplitudeGain = Mathf.Lerp(amplitude, 0f, progress);
            yield return null;
        }
        _virtualCameraNoise.m_AmplitudeGain = 0;
        _virtualCameraNoise.m_FrequencyGain = 0;
    }
}
