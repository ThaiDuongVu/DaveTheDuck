using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int unlockedLevels;
    public TextMeshProUGUI levelNumber;

    private int selectedLevel;

    public StarsController starsController;
    public Animator menuAnimator;

    public int maxLevels;

    private Color32 lockedTextColor;
    private Color32 unlockedTextColor;

    public Image lockImage;

    private void Start()
    {
        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        selectedLevel = unlockedLevels;

        unlockedTextColor = levelNumber.color;
        lockedTextColor = levelNumber.color;
        lockedTextColor.a = 150;

        PlayerPrefs.SetInt("MaxLevels", maxLevels);
        UpdateLevelNumber();
    }

    public void ToggleLevel(string direction)
    {
        if (direction.Equals("left"))
        {
            if (selectedLevel > 1)
            {
                selectedLevel--;
            }
        }
        else
        {
            if (selectedLevel < maxLevels)
            {
                selectedLevel++;
            }
        }

        UpdateLevelNumber();
    }

    private void UpdateLevelNumber()
    {
        if (selectedLevel < 10)
        {
            levelNumber.text = "0" + selectedLevel.ToString();
        }
        else
        {
            levelNumber.text = selectedLevel.ToString();
        }

        if (selectedLevel > unlockedLevels)
        {
            levelNumber.color = lockedTextColor;
            lockImage.gameObject.SetActive(true);
        }
        else
        {
            levelNumber.color = unlockedTextColor;
            lockImage.gameObject.SetActive(false);
        }

        starsController.SetStars(PlayerPrefs.GetInt("Rating" + selectedLevel, 0));
        menuAnimator.SetTrigger("starsPop");
    }

    public int GetSelectedLevel()
    {
        return selectedLevel;
    }
}
