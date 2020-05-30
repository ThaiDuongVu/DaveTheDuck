using UnityEngine;

public class FloorController : MonoBehaviour
{
    
    private void Update()
    {
        SetRotation();
    }

    private void SetRotation()
    {
        Quaternion rotation = gameObject.transform.rotation;
        Vector3 rotationEuler = rotation.eulerAngles;

        rotationEuler.x = 0f;
        rotationEuler.y = 45f;
        rotationEuler.z = 0;

        rotation.eulerAngles = rotationEuler;
        gameObject.transform.rotation = rotation;
    }
}
