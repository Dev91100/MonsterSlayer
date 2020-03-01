using Cinemachine;
using UnityEngine;

// This script controls the screen shake effect which is applied to the Main Camera

// This script is attached to the Main Camera

/* 
    gamesplusjames, 2019 : Adding ScreenShake In Unity
    Available from: https://www.youtube.com/watch?v=8PXPyyVu_6I&list=LLH3a8ESny180HvT46FvAlAw&index=9
*/

public class Knight_CameraShake : MonoBehaviour
{
    public static Knight_CameraShake instance; // This will enable the script to be used as a reference in other scripts
  
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation; // Parameters of the camera shake

    public float rotationMultiplier; // Controls how much the screen shake rotates

    private CinemachineBrain cam; // Enables the programmer to add a camera in the inspector
    private Animator animator; // Enables the programmer to add an animator in the inspector

    void Start()
    {
        // This will enable the script to be used as a reference in other scripts
        instance = this;
        cam = GetComponent<CinemachineBrain>();
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0) // Check if we have any shake time remaining
        {
            shakeTimeRemaining -= Time.deltaTime; // Shake time remaining countdown

            float xAmount = Random.Range(-0.1f, 0.5f) * shakePower; // Randomly pick a number between -0.1f & 0.5f for the shake along the x axis
            float yAmount = Random.Range(-0.1f, 0.5f) * shakePower; // Randomly pick a number between -0.1f & 0.5f for the shake along the y axis

            transform.position += new Vector3(xAmount, yAmount, 0f); // Moves the camera with the values of xAmount & yAmount

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime); // Controls how fast the screen shake will fade out

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier); // Controls how much the screen shake rotates
        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f)); // Applies the screen shake rotation

    }

    // This function controls the different parameters of the screen shake effect

    public void startShake(float length, float power)
    {
        shakeTimeRemaining = length;                    // Controls how long the screen shake will last for
        shakePower = power;                             // Controls how powerful the screen shake is going to be
        shakeFadeTime = power / length;                 // Controls how fast the screen shake will fade out
        shakeRotation = power * rotationMultiplier;     // Controls how much the screen shake rotates

    }
}
