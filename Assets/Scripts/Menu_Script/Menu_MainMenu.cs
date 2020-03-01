using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD:Assets/Scripts/Menu_Script/Menu_Script.cs
public class Menu_Script : MonoBehaviour
=======
public class Menu_MainMenu : MonoBehaviour
>>>>>>> 55e6eb47bfae660b38783cb49b011a8580bf79f6:Assets/Scripts/Menu_Script/Menu_MainMenu.cs
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("The game has been closed");
        Application.Quit();
    }
}
