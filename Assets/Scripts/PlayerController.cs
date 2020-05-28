using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float speed = 15f;

    private void Start()
    {

    }


    private void Update()
    {
        MovementControl();
    }

    private void MovementControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement != Vector3.zero)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(movement);
        }
        gameObject.transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
