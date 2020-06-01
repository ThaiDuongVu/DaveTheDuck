using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject floor;
    public GameObject floorFeatures;
    private GameObject[] tiles;

    private int tileCount;

    private bool gameStart;
    private float countDown = 3f;

    public Canvas canvas;
    public Canvas secondaryCanvas;
    private bool canvasVisible;

    public GameObject player;
    public CursorController cursorController;

    private bool gameOver;
    public GameObject gameOverMenu;
    public GameObject stars;

    public GameObject instructionsInGame;
    public GameObject instructionsMenu;

    public Button nextLevelButton;

    public float timer;

    private int rating;
    private int[] ratingMarker;

    public int levelNumber;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        tileCount = floor.transform.childCount;
        tiles = new GameObject[tileCount];
    }
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursorController.HideCursor();

        gameStart = false;

        gameOverMenu.SetActive(false);
        gameOver = false;

        timer += 1f;
        countDown += 1f;

        secondaryCanvas.enabled = false;
        canvasVisible = true;

        instructionsInGame.SetActive(true);
        instructionsMenu.SetActive(false);

        if (levelNumber < 10)
        {
            levelText.text = "Level 0" + levelNumber;
        }
        else
        {
            levelText.text = "Level " + levelNumber;
        }

        SetRatingMarker();
    }
    
    private void Update()
    {
        if (gameStart)
        {
            TimerControl();
            TileCountControl();

            HideCanvas();
        }
        else
        {
            StartGame();
        }
    }

    private void TimerControl()
    {
        if (timer > 1f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (!gameOver)
            {
                SetGameOver();
                gameOverMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Level Failed";

                rating = 0;
            }
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    private void SetGameOver()
    {
        gameOverMenu.SetActive(true);
        stars.GetComponent<StarsController>().SetStars(rating);

        cursorController.ShowCursor();
        gameOverMenu.GetComponent<Animator>().SetTrigger("slideIn");

        instructionsInGame.SetActive(false);
        instructionsMenu.SetActive(true);

        if (rating <= 0)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
        else
        {
            if (levelNumber < PlayerPrefs.GetInt("MaxLevels"))
            {
                if (PlayerPrefs.GetInt("UnlockedLevels", 1) <= levelNumber)
                {
                    PlayerPrefs.SetInt("UnlockedLevels", levelNumber + 1);
                }
            }
            
            if (PlayerPrefs.GetInt("Rating" + levelNumber, 0) < rating)
            {
                PlayerPrefs.SetInt("Rating" + levelNumber, rating);
            }
        }

        gameOver = true;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    private void StartGame()
    {
        if (countDown > 1)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            gameStart = true;
        }
    }

    public float GetCountDown()
    {
        return countDown;
    }

    public bool GetGameStart()
    {
        return gameStart;
    }

    public int GetRating()
    {
        return rating;
    }

    private void SetRatingMarker()
    {
        ratingMarker = new int[3];
        for (int i = 0; i < 3; i++)
        {
            ratingMarker[i] = (int)((timer / 3f) * i);
        }
    }

    private void TileCountControl()
    {
        if (tileCount <= 0)
        {
            if (!gameOver)
            {
                if (timer >= ratingMarker[2])
                {
                    rating = 3;
                }
                else if (timer < ratingMarker[2] && timer >= ratingMarker[1])
                {
                    rating = 2;
                }
                else
                {
                    rating = 1;
                }

                SetGameOver();
            }
        }
    }

    public void DecreaseTile()
    {
        tileCount--;
    }

    private void HideCanvas()
    {
        if (gameOver)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (canvasVisible)
                {
                    canvas.enabled = false;
                    canvasVisible = false;

                    secondaryCanvas.enabled = true;
                    if (floorFeatures != null)
                    {
                        floorFeatures.SetActive(false);
                    }

                    Camera.main.GetComponent<Animator>().SetTrigger("pan");
                    player.SetActive(false);
                }
            }
            if (Input.GetButtonUp("Fire2"))
            {
                if (!canvasVisible)
                {
                    canvas.enabled = true;
                    canvasVisible = true;

                    secondaryCanvas.enabled = false;
                    if (floorFeatures != null)
                    {
                        floorFeatures.SetActive(true);
                    }

                    Camera.main.GetComponent<Animator>().SetTrigger("panBack");
                    player.SetActive(true);
                }
            }
        }
    }
}
