using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Canvas canvas;
    private Animator cameraAnimator;
    public CameraController cameraController;

    public LevelManager levelManager;
    public GameController gameController;

    private void Awake()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
    }
    
    private void PrepareLoadScene()
    {
        canvas.enabled = false;
        cameraAnimator.SetTrigger("zoomIn");
    }

    public void Home()
    {
        PrepareLoadScene();
        cameraController.SetSceneToLoad("Home");
    }

    public void Restart()
    {
        PrepareLoadScene();
        cameraController.SetSceneToLoad(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        PrepareLoadScene();

        if (gameController.levelNumber < 10)
        {
            cameraController.SetSceneToLoad("Level0" + (gameController.levelNumber + 1));
        }
        else
        {
            cameraController.SetSceneToLoad("Level" + (gameController.levelNumber + 1));
        }
    }

    public void PlayLevels()
    {
        if (levelManager.GetSelectedLevel() <= PlayerPrefs.GetInt("UnlockedLevels", 1))
        {
            PrepareLoadScene();
            if (levelManager.GetSelectedLevel() < 10)
            {
                cameraController.SetSceneToLoad("Level0" + levelManager.GetSelectedLevel());
            }
            else
            {
                cameraController.SetSceneToLoad("Level" + levelManager.GetSelectedLevel());
            }
        }
    }
}
