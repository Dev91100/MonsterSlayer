using UnityEngine;
using UnityEngine.SceneManagement;

// This script adds functionality to the "Start Game" button and the "Exit" button

// This script is attached to Menu_MainMenu

public class Menu_MainMenu : MonoBehaviour
{
    // This function controls the play button
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene
    }

    // This function quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}