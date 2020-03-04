using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script enables us to add a transition between scenes

// This script is attached to Level_LevelFadeIn

/* 
    Brackeys, 2020 : How to make AWESOME Scene Transitions in Unity!
    Available from: https://www.youtube.com/watch?v=CE9VOZivb3I&t=724s
*/

public class Level_LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f; // Enables the programmer to set the waiting time before loading a scene


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // Get current scene index and add 1 to it
    }

    // This coroutine enables the trigger to start transition animation and waits an amount of time before transitioning to the next scene 

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


}
