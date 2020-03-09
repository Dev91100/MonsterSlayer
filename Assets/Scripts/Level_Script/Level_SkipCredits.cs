using UnityEngine;
using UnityEngine.SceneManagement;

// This script enables the user to skip the EndCredits scene to be skipped when the escape key is pressed

// This script is attached to Level_SkipCredit

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