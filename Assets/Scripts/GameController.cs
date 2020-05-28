﻿using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject floor;
    private GameObject[] tiles;

    private int tileCount;

    private bool gameOver;

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
        gameOver = false;
    }

    
    private void Update()
    {
        TimerControl();
        TileCountControl();
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
                starRating = 0;
            }
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    public bool GetGameOver()
    {
        return gameOver;
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
                gameOver = true;
            }
        }
    }

    public void DecreaseTile()
    {
        tileCount--;
    }
}
