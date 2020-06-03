using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    private string sceneToLoad;

    public PostProcessProfile postProcessProfile;
    private DepthOfField depthOfField;

    private void Start()
    {
        postProcessProfile.TryGetSettings(out depthOfField);
        DisableDepthOfField();
    }
    
    private void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }

    public void SetSceneToLoad(string sceneToLoad)
    {
        this.sceneToLoad = sceneToLoad;
    }

    public void EnableDepthOfField()
    {
        depthOfField.enabled.value = true;
    }

    public void DisableDepthOfField()
    {
        depthOfField.enabled.value = false;
    }
}
