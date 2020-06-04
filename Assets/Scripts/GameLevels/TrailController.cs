using UnityEngine;

public class TrailController : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        
    }
    
    private void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector3 position = player.transform.position;
        position.y = player.transform.position.y - 0.2f;

        gameObject.transform.position = position;
    }
}
