using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    private string sceneToLoad;

    public PostProcessProfile postProcessProfile;
    private DepthOfField depthOfField;

    private string postProcessingMode;

    public PostProcessLayer postProcessLayer;

    private void Start()
    {
        postProcessProfile.TryGetSettings(out depthOfField);
        DisableDepthOfField();

        postProcessingMode = "On";
    }

    private void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
        SetPostProcessing();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            postProcessLayer.enabled = false;
        }
    }

    private void SetPostProcessing()
    {
        if (postProcessingMode != PlayerPrefs.GetString("PostProcessing", "On"))
        {
            if (postProcessingMode.Equals("On"))
            {
                gameObject.GetComponent<PostProcessVolume>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<PostProcessVolume>().enabled = true;
            }
            postProcessingMode = PlayerPrefs.GetString("PostProcessing", "On");
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
