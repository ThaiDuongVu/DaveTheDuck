using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private Vector2 mousePos;

    public GameObject floor;
    private GameObject[] tiles;

    private int tileCount;

    private bool gameStart;
    private float countDown = 3f;

    public Canvas canvas;
    private bool canvasVisible;

    public GameObject player;

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

        canvasVisible = true;
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

                    player.SetActive(false);
                }
            }
            if (Input.GetButtonUp("Fire2"))
            {
                if (!canvasVisible)
                {
                    canvas.enabled = true;
                    canvasVisible = true;

                    player.SetActive(true);
                }
            }
        }
    }
}
