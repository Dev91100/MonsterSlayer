using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_SceneSwitch : MonoBehaviour
{
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
