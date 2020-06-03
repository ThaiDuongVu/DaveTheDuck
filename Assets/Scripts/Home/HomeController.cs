using UnityEngine;

public class HomeController : MonoBehaviour
{
    private bool menuSlideIn;
    public Animator menuAnimator;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        menuSlideIn = false;
    }

    private void Update()
    {
        if (!menuSlideIn)
        {
            if (Camera.main.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Empty"))
            {
                menuAnimator.SetTrigger("slideIn");
                Camera.main.GetComponent<CameraController>().EnableDepthOfField();
                menuSlideIn = true;
            }
        }
    }
}
