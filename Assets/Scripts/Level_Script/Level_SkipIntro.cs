using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
// This script enables the user to switch scene by pressing on the skip button

// This script is attached to Level_SkipButton

=======
>>>>>>> 91ce6acbca5a1e9c46b8cbe4a2e8bc29ef13437d
public class Level_SkipIntro : MonoBehaviour
{
    public void skipIntro(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
