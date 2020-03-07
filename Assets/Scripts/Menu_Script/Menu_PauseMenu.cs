using UnityEngine;
using UnityEngine.SceneManagement;

// This script enables us to pause the game and bring up the pause menu

// This script is attached to Level_PauseMenuCanvas

/* 
    Brackeys, 2017 : PAUSE MENU in Unity
    Available from: https://www.youtube.com/watch?v=JivuXdrIHK0
*/

public class Menu_PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; // Check if the game is paused or not
    public GameObject pauseMenuUI;
    private int currentScene;
    private int startCoin;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        startCoin = Power_ScoreTextScript.coinAmount;
    }

    void Update()
    {
        // Check if escape key has been pressed down to enable or disable the pause menu

        if(Input.GetKeyDown(KeyCode.Escape))
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
    }

    // This function enables the pause menu UI

    void Pause()
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
        Level_GameOver.gameOverUI.SetActive(false);
        SceneManager.LoadScene(currentScene);
    }

    // This function starts the scene Menu_MainMenuScene

    public void LoadMenu()
    {
        Power_ScoreTextScript.coinAmount = 0;
        Time.timeScale = 1f;
        Level_GameOver.gameOverUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
