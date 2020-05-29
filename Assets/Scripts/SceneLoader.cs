using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject gameOverMenu;
    private Animator cameraAnimator;
    public CameraController cameraController;

    private void Awake()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
    }
    
    private void Start()
    {
        
    }

    
    private void Update()
    {
        
    }

    public void Home()
    {

    }

    public void Restart()
    {
        gameOverMenu.SetActive(false);
        cameraAnimator.SetTrigger("zoomIn");

        cameraController.SetSceneToLoad(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {

    }
}
