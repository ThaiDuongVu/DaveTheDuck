using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    private string size = "small";
    private float smallScale = 1f;
    private float largeScale = 1.3f;

    public TextMeshProUGUI instructionText;
    public string instruction;
    private bool instructionAlreadySet;

    private void Start()
    {
        instructionAlreadySet = false;
    }

    public void SetSize(string newSize)
    {
        if (newSize.Equals("large"))
        {
            if (size.Equals("small"))
            {
                Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;

                scale.x = largeScale;
                scale.y = largeScale;

                gameObject.GetComponent<RectTransform>().localScale = scale;

                size = "large";
            }
        }
        else
        {
            if (size.Equals("large"))
            {
                Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;

                scale.x = smallScale;
                scale.y = smallScale;

                gameObject.GetComponent<RectTransform>().localScale = scale;

                size = "small";
            }
        }
    }

    public void SetInstructionText()
    {
        if (!instructionAlreadySet)
        {
            instructionText.text = instruction;
            instructionAlreadySet = true;
        }
    }

    public void ResetInstruction()
    {
        if (instructionAlreadySet)
        {
            instructionAlreadySet = false;
            instructionText.text = "";
        }
    }
}
