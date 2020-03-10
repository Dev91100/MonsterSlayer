using UnityEngine;
using UnityEngine.Video;

// This script preloads the intro video

// This script is attached to Level_PreloadVideo

public class Level_VideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlane;

    void Start()
    {
        videoPlane.Prepare();
    }
}
