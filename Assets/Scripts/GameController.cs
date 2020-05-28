using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject floor;
    private GameObject[] tiles;

    public int tileCount;

    private bool gameOver;

    public float timer;

    private void Awake()
    {
        tileCount = floor.transform.childCount;
        tiles = new GameObject[tileCount];
    }
    
    private void Start()
    {
        Cursor.visible = false;
        gameOver = false;
    }

    
    private void Update()
    {
        TimerControl();
    }

    private void TimerControl()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (!gameOver)
            {
                gameOver = true;
            }
        }
    }

    public float GetTimer()
    {
        return timer;
    }
}
