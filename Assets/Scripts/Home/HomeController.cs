using UnityEngine;

public class HomeController : MonoBehaviour
{
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Camera.main.GetComponent<Animator>().SetTrigger("gameOver");
    }
    
    private void Update()
    {
        
    }
}
