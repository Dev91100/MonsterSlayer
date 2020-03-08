using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_SkipCredits : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}