using UnityEngine;
using TMPro;

public class SettingsController : MonoBehaviour
{
    private string fullScreen;
    public TextMeshProUGUI fullScreenText;

    private int[] resolutionX = new int[5];
    private int[] resolutionY = new int[5];
    private int resolutionIndex;
    public TextMeshProUGUI resolutionText;

    private string aud;
    public TextMeshProUGUI audioText;

    private string showFPS;
    public TextMeshProUGUI fpsText;

    private string font;
    public TextMeshProUGUI fontText;
    
    private void Start()
    {
        fullScreen = PlayerPrefs.GetString("FullScreen", "On");
        aud = PlayerPrefs.GetString("Audio", "On");
        resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);

        resolutionX[0] = 1920;
        resolutionX[1] = 1600;
        resolutionX[2] = 1366;
        resolutionX[3] = 1280;
        resolutionX[4] = 1024;

        resolutionY[0] = 1080;
        resolutionY[1] = 900;
        resolutionY[2] = 768;
        resolutionY[3] = 720;
        resolutionY[4] = 576;

        showFPS = PlayerPrefs.GetString("ShowFPS", "On");
        font = PlayerPrefs.GetString("Font", "Stylized");

        Apply();
    }

    public void ToggleFullScreen()
    {
        if (fullScreen.Equals("On"))
        {
            fullScreen = "Off";
        }
        else
        {
            fullScreen = "On";
        }
        Apply();
    }

    public void ToggleAudio()
    {
        if (aud.Equals("On"))
        {
            aud = "Off";
        }
        else
        {
            aud = "On";
        }
        Apply();
    }

    public void ToggleResolution(string direction)
    {
        if (direction.Equals("left"))
        {
            if (resolutionIndex == 0)
            {
                resolutionIndex = resolutionX.Length - 1;
            }
            else
            {
                resolutionIndex--;
            }
        }
        else
        {
            if (resolutionIndex == resolutionX.Length - 1)
            {
                resolutionIndex = 0;
            }
            else
            {
                resolutionIndex++;
            }
        }
        Apply();
    }

    public void ToggleShowFPS()
    {
        if (showFPS.Equals("On"))
        {
            showFPS = "Off";
        }
        else
        {
            showFPS = "On";
        }

        Apply();
    }

    public void ToggleFont()
    {
        if (font.Equals("Stylized"))
        {
            font = "Basic";
        }
        else
        {
            font = "Stylized";
        }

        Apply();
    }

    private void Apply()
    {
        PlayerPrefs.SetString("FullScreen", fullScreen);
        fullScreenText.text = fullScreen;

        PlayerPrefs.SetString("Audio", aud);
        audioText.text = aud;

        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        resolutionText.text = resolutionX[resolutionIndex].ToString() + "." + resolutionY[resolutionIndex].ToString();

        PlayerPrefs.SetString("ShowFPS", showFPS);
        fpsText.text = showFPS;

        PlayerPrefs.SetString("Font", font);
        fontText.text = font;

        if (fullScreen.Equals("On"))
        {
            Screen.SetResolution(resolutionX[resolutionIndex], resolutionY[resolutionIndex], true);
        }
        else
        {
            Screen.SetResolution(resolutionX[resolutionIndex], resolutionY[resolutionIndex], false);
        }
    }
}
