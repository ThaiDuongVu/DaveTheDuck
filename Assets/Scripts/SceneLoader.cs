﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject gameOverMenu;
    private Animator cameraAnimator;
    public CameraController cameraController;

    private void Awake()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
    }
    
    private void PrepareLoadScene()
    {
        gameOverMenu.SetActive(false);
        cameraAnimator.SetTrigger("zoomIn");
    }

    public void Home()
    {
        PrepareLoadScene();
        cameraController.SetSceneToLoad("Home");
    }

    public void Restart()
    {
        PrepareLoadScene();
        cameraController.SetSceneToLoad(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        PrepareLoadScene();
        // cameraController.SetSceneToLoad("NextScene");
    }
}