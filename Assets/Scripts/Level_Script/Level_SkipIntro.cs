using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_SkipIntro : MonoBehaviour
{
    public void skipIntro(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
