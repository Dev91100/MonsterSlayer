using UnityEngine;

// This script gives a parallax effect to the background

// This script is attached to the background images

/* 
    Dani, 2019 : Unity Parallax Tutorial - How to infinite scrolling background [online].
    Available from: https://www.youtube.com/watch?v=zit45k6CUMk
*/

public class Knight_Parallax : MonoBehaviour
{
    private float length, startpos; // To track the length and position of the player
    public GameObject cam;          // Allow the programmer to assign a camera in the inspector
    public float parallaxEffect;    // To set the amount of parallax effect to apply

    void Start()
    {
        startpos = transform.position.x;                        // Give the start position of the player
        length = GetComponent<SpriteRenderer>().bounds.size.x;  // Give the length of the player
    }
    
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); // How far the player has moved relative to the camera
        float dist = (cam.transform.position.x * parallaxEffect);       // How far the player has moved in world space

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);  // Move the camera

        // Make the background repeat itself

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;


    }
   
}
