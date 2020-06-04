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
        font = "Stylized";
    }

    private void Update()
    {
        SetFont();

        if (gameObject.name.Equals("BonusText"))
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Empty"))
            {
                Destroy(gameObject);
            }
        }
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
