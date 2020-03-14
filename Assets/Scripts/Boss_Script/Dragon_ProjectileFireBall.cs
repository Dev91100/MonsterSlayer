using UnityEngine;

// This script controls the fireballs

// This script is attached to Boss_RedDragron

public class Dragon_ProjectileFireBall : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        // This if statement controls how fast the dragon can shoot the fireballs
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, shotPoint.position, transform.rotation); // (GameObject, Vector3 postion, Quaternion Rotation)
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
