using Cinemachine;
using UnityEngine;

public class Knight_CameraShake : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower;

    public GameObject cineCamFind, cineCamActive, cineCamDeactive;

    private CinemachineBrain cam;
    private Animator animator;

    void Start()
    {
        cam = GetComponent<CinemachineBrain>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.enabled = false;
            cam.enabled = false;
            startShake(.1f, .3f);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.enabled = true;
            cam.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
        }
    }

    public void startShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

    }
}
