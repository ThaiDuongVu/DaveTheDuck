using UnityEngine;

public class FloorController : MonoBehaviour
{
    
    private void Start()
    {
        SetInitRotation();
    }

    private void SetInitRotation()
    {
        Quaternion rotation = gameObject.transform.rotation;
        Vector3 rotationEuler = rotation.eulerAngles;

        rotationEuler.y = 45f;

        rotation.eulerAngles = rotationEuler;
        gameObject.transform.rotation = rotation;
    }
}
