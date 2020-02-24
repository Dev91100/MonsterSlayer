using Cinemachine;
using UnityEngine;

public class Knight_CameraShake : MonoBehaviour
{
    public static Knight_CameraShake instance;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    public float rotationMultiplier;

    private CinemachineBrain cam;
    private Animator animator;

    void Start()
    {
        instance = this;
        cam = GetComponent<CinemachineBrain>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    animator.enabled = false;
        //    cam.enabled = false;
        //    startShake(.1f, .7f);
        //}

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    animator.enabled = true;
        //    cam.enabled = true;
        //}
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier);


        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));

    }

    public void startShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;

    }
}
