using UnityEngine;
using UnityEngine.SceneManagement;

// This script enables the user to switch scene by pressing on the skip button

// This script is attached to Level_SkipButton

public class Level_SkipIntro : MonoBehaviour
{
    public void skipIntro(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
