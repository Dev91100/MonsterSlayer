using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script will control the patrolling enemies
// It is attached to the common enemies

/* 
TRGameDev, 2017 : Quick and Simple Unity Patrol AI in Less Than 10 Minutes C#
Available from: https://www.youtube.com/watch?v=we44Z3yR2Ec
*/

public class Monster_Walking : MonoBehaviour
{
    public Rigidbody2D rb;           
    public SpriteRenderer sr;
    public float speed = 2;

    void FixedUpdate()
    {
       rb.velocity = Vector2.right * speed;         // This will make the enemy move towards the right
    }

    // This fucntion will make the enemy move in a limited area
    // It detects when two object collides
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Limit")         // If the enemy collides with the object limit
        {
            if (sr.flipX == false)                 // This will flip the monster making it turn around
            {
                sr.flipX = true; 
                speed = -2;                        // Moving the monster in the way it is facing
            }
            else
            {
                sr.flipX = false;
                speed = 2;
            }
        }
    }
}
