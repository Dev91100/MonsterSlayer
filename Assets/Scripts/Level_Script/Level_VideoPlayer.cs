using UnityEngine;
using UnityEngine.Video;

public class Level_VideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlane;

    void Start()
    {
        videoPlane.Prepare();
    }
}
