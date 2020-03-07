using UnityEngine;
using UnityEngine.SceneManagement;

// This script enables us to pause the game and bring up the pause menu

// This script is attached to Level_PauseMenuCanvas

/* 
    Brackeys, 2017 : PAUSE MENU in Unity
    Available from: https://www.youtube.com/watch?v=JivuXdrIHK0
*/

public class Level_GameOver : MonoBehaviour
{
    private int currentScene;
    private int startCoin;
    public GameObject gameOverUI;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        startCoin = Power_ScoreTextScript.coinAmount;
    }

    void Update()
    {
        if (Knight_Combat.currenthealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Power_ScoreTextScript.coinAmount = startCoin;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(currentScene);
    }

    public void LoadMenu()
    {
        Power_ScoreTextScript.coinAmount = 0;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
