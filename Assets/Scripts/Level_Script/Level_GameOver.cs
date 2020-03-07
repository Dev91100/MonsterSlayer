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
    public static GameObject gameOverUI;

    void Update()
    {
        // Check if escape key has been pressed down to enable or disable the pause menu

        if (Knight_Combat.die == true)
        {
            GameOver();
        }
    }

    // This function enables the pause menu UI

    void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
