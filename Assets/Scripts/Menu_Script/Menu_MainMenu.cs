using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("The game has been closed");
        Application.Quit();
    }
}