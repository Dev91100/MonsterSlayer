using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_SkipIntro : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 39f;

    [SerializeField]
    private string sceneNameToLoad;

    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    public void skipIntro(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
