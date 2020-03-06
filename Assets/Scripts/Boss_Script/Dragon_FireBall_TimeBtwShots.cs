using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_FireBall_TimeBtwShots : MonoBehaviour
{

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()

    {

        //How Fast The Dragon Can Shoot The Fireballs
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
