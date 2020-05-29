using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float speed = 15f;
    private float mouseAccelerator = 1.5f;
    private bool isRunning;

    private Animator animator;
    public GameController gameController;

    private Vector3 playerPosition;
    private Vector3 clampPosition = new Vector3(12f, 0.8f, 12f);

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        MovementControl();
    }

    private void MovementControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * mouseAccelerator;
        float mouseY = Input.GetAxis("Mouse Y") * mouseAccelerator;

        Vector3 movement = new Vector3(horizontal + mouseX, 0f, vertical + mouseY);

        if (movement != Vector3.zero)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(movement);
        }
        if (!gameController.GetGameOver() && gameController.GetGameStart())
        {
            gameObject.transform.Translate(movement * speed * Time.deltaTime, Space.World);
            ClampMovement();
        }

        AnimationControl(movement);
    }

    private void ClampMovement()
    {
        playerPosition = gameObject.transform.position;

        if (playerPosition.x > clampPosition.x)
        {
            playerPosition.x = clampPosition.x;
        }
        else if (playerPosition.x < -clampPosition.x)
        {
            playerPosition.x = -clampPosition.x;
        }

        if (playerPosition.z > clampPosition.z)
        {
            playerPosition.z = clampPosition.z;
        }
        else if (playerPosition.z < -clampPosition.z)
        {
            playerPosition.z = -clampPosition.z;
        }

        gameObject.transform.position = playerPosition;
    }

    private void AnimationControl(Vector3 movement)
    {
        if (movement == Vector3.zero)
        {
            if (isRunning)
            {
                animator.SetBool("run", false);
                isRunning = false;
            }
        }
        else
        {
            if (!isRunning)
            {
                animator.SetBool("run", true);
                isRunning = true;
            }
        }

        if (gameController.GetGameOver())
        {
            if (isRunning)
            {
                animator.SetBool("run", false);
                isRunning = false;
            }
        }
    }
}
