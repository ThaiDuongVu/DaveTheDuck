using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Vector2 mousePos;

    public GameObject floor;
    private GameObject[] tiles;

    private int tileCount;

    private bool gameStart;
    private float countDown = 3f;

    private bool gameOver;
    public GameObject gameOverMenu;
    public GameObject stars;

    public float timer;

    private int starRating;
    public int[] ratingMarker;

    private void Awake()
    {
        tileCount = floor.transform.childCount;
        tiles = new GameObject[tileCount];
    }
    
    private void Start()
    {
        Cursor.visible = false;
        mousePos = Vector2.zero;

        gameStart = false;

        gameOverMenu.SetActive(false);
        gameOver = false;

        timer += 1f;
        countDown += 1f;
    }
    
    private void Update()
    {
        if (gameStart)
        {
            TimerControl();
            TileCountControl();
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
                gameOverMenu.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level Failed";

                starRating = 0;
            }
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    private void SetGameOver()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("gameOver");
        Cursor.visible = true;

        gameOverMenu.SetActive(true);
        stars.GetComponent<StarsController>().SetStars(starRating);

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
        return starRating;
    }

    private void TileCountControl()
    {
        if (tileCount <= 0)
        {
            if (!gameOver)
            {
                if (timer >= ratingMarker[2])
                {
                    starRating = 3;
                }
                else if (timer < ratingMarker[2] && timer >= ratingMarker[1])
                {
                    starRating = 2;
                }
                else
                {
                    starRating = 1;
                }

                SetGameOver();
            }
        }
    }

    public void DecreaseTile()
    {
        tileCount--;
    }
}
