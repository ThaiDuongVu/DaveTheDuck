using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    private string font;

    public TMP_FontAsset stylized;
    public TMP_FontAsset roboto;

    private TextMeshProUGUI textUI;
    private TextMeshPro text;

    private void Awake()
    {
        if (gameObject.name.Equals("BonusText"))
        {
            text = gameObject.GetComponent<TextMeshPro>();
        }
        else
        {
            textUI = gameObject.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        font = "Stylized";
    }

    private void Update()
    {
        SetFont();
    }

    private void SetFont()
    {
        if (font != PlayerPrefs.GetString("Font", "Stylized"))
        {
            if (font.Equals("Stylized"))
            {
                if (textUI != null)
                {
                    textUI.font = roboto;
                }
                else
                {
                    text.font = roboto;
                }
            }
            else
            {
                if (textUI != null)
                {
                    textUI.font = stylized;
                }
                else
                {
                    text.font = stylized;
                }
            }

            font = PlayerPrefs.GetString("Font", "Stylized");
        }
    }
}
