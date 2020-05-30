using UnityEngine;

public class StarsController : MonoBehaviour
{
    private GameObject[] stars;
    private int starsNum;

    private void Awake()
    {
        starsNum = gameObject.transform.childCount;
        stars = new GameObject[starsNum];

        for (int i = 0; i < starsNum; i++)
        {
            stars[i] = gameObject.transform.GetChild(i).gameObject;
            stars[i].SetActive(false);
        }
    }

    public void SetStars(int rating)
    {
        for (int i = 0; i < starsNum; i++)
        {
            stars[i].SetActive(false);
        }

        for (int i = 0; i < rating; i++)
        {
            stars[i].SetActive(true);
        }
    }
}
