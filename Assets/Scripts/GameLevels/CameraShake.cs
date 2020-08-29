using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;

    private float shakeDuration = 0f;
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;

    private Vector3 originalPosition;

    private void Awake()
    {
        cameraTransform = gameObject.transform;
    }

    private void OnEnable()
    {
        originalPosition = cameraTransform.position;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void Shake()
    {
        shakeDuration = 0.2f;
        shakeAmount = 0.3f;
        decreaseFactor = 2f;
    }

    public void ShakeLight()
    {
        shakeDuration = 0.05f;
        shakeAmount = 0.05f;
        decreaseFactor = 2f;
    }
}
