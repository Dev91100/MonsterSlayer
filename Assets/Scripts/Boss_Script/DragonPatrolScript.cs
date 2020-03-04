using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPatrolScript : MonoBehaviour
{
    public Rigidbody2D Dragon_rb;
    public SpriteRenderer Dragon_sr;
    public float Dragon_speed = 8;
    public bool moveRight;


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boss_FlipCollider"))
        {
            if (moveRight)
            {
                moveRight = false;

            }
            else
            {
                moveRight = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveRight)
        {
            Dragon_rb.velocity = Vector2.right * Dragon_speed;

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            Dragon_rb.velocity = Vector2.left * Dragon_speed;

            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }


}

/*"Is Trigger turned on for the Dragon and the "Flip" box colliders
 */
