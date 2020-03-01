using UnityEngine;
using UnityEngine.SceneManagement;

// This script enables the scenes to be switched when the player gets to the end of a level

// This script is attached to Level_SceneTrigger

public class Level_SceneSwitch : MonoBehaviour
{
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; // Gets the index of the next scene
    }


    // Switch scene when the player gets in the trigger zone

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
