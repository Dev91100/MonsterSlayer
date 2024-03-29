﻿using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the pause menu and the game over menu

// This script is attached to Level_PauseandGameOverCanvas

/*
    Brackeys, 2017 : PAUSE MENU in Unity [online].
    Available from: https://www.youtube.com/watch?v=JivuXdrIHK0
*/

public class Menu_PauseandGameOverMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; // Check if the game is paused or not
    public GameObject pauseMenuUI;
    private int currentScene;
    private int startCoin;
    public GameObject gameOverUI;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        startCoin = Power_ScoreTextScript.coinAmount;
    }

    private void Update()
    {
        // Check if escape key has been pressed down to enable or disable the pause menu

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Knight_Combat.currenthealth <= 0)
        {
            GameOver();
        }
    }

    // This function enables the pause menu UI

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freezes the game
        gameIsPaused = true;
    }

    // This function resumes the game

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Unfreezes the game
        gameIsPaused = false;
    }

    // This function restarts the current scene

    public void Restart()
    {
        Power_ScoreTextScript.coinAmount = startCoin;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene);
    }

    // This function starts the scene Menu_MainMenuScene

    public void LoadMenu()
    {
        Power_ScoreTextScript.coinAmount = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //This function enables the game over menu

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}