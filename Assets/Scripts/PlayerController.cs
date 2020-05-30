using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float speed = 15f;
    private bool isRunning;

    private Animator animator;
    public GameController gameController;

    private Vector3 clampPosition = new Vector3(12f, 0.8f, 12f);

    private string controlScheme = "";

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

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 joystickMovement = new Vector3(horizontal, 0f, vertical);
        Vector3 mouseMovement = new Vector3(mouseX, 0f, mouseY);

        if (!gameController.GetGameOver() && gameController.GetGameStart())
        {
            if (joystickMovement != Vector3.zero)
            {
                gameObject.transform.rotation = Quaternion.LookRotation(joystickMovement);
            }

            gameObject.transform.Translate((joystickMovement + mouseMovement) * speed * Time.deltaTime, Space.World);
            ClampMovement();
        }
        AnimationControl(joystickMovement);
        ControlScheme(joystickMovement, mouseMovement);
    }

    private void ClampMovement()
    {
        Vector3 playerPosition;
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
        if (gameController.GetGameOver())
        {
            if (isRunning)
            {
                animator.SetBool("run", false);
                isRunning = false;
            }
        }
        else
        {
            if (gameController.GetGameStart())
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
            }
        }
    }

    private void ControlScheme(Vector3 joystickMovement, Vector3 mouseMovement)
    {
        if (mouseMovement != Vector3.zero)
        {
            if (controlScheme.Equals("gamepad") || controlScheme.Equals(""))
            {
                controlScheme = "mouse";
            }
        }
        if (joystickMovement != Vector3.zero)
        {
            if (controlScheme.Equals("mouse") || controlScheme.Equals(""))
            {
                controlScheme = "gamepad";
            }
        }
    }

    public string GetControlScheme()
    {
        return controlScheme;
    }
}
