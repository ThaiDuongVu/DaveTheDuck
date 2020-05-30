using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private string size = "small";

    public void SetSize(string newSize)
    {
        if (newSize.Equals("large"))
        {
            if (size.Equals("small"))
            {
                Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;

                scale.x = 1.5f;
                scale.y = 1.5f;

                gameObject.GetComponent<RectTransform>().localScale = scale;

                size = "large";
            }
        }
        else
        {
            if (size.Equals("large"))
            {
                Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;

                scale.x = 1f;
                scale.y = 1f;

                gameObject.GetComponent<RectTransform>().localScale = scale;

                size = "small";
            }
        }
    }

    public string GetSize()
    {
        return size;
    }
}
