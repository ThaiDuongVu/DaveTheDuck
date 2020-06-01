using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    private string font;

    public TMP_FontAsset stylized;
    public TMP_FontAsset roboto;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    private void Start()
    {
        font = "Stylized";//PlayerPrefs.GetString("Font", "Stylized");
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
                text.font = roboto;
            }
            else
            {
                text.font = stylized;
            }

            font = PlayerPrefs.GetString("Font", "Stylized");
        }
    }
}
