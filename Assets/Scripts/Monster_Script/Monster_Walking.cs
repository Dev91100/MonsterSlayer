using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Walking : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float speed = 2;

    //public Transform detect;
    //public float range = 0.5f;
    //public LayerMask player;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    //void Update()
    //{
    //    Collider2D[] hitplayer = Physics2D.OverlapCircleAll(detect.position, range, player);


    //    foreach (Collider2D player in hitplayer)
    //    {
    //        if (transform.position.x > player.transform.position.x)
    //        {
    //            sr.flipX = true;
    //            speed = -2f;
    //        }
    //        else
    //        {
    //            sr.flipX = false;
                
    //            speed = 2f;
    //        }
    //    }
    //}

    void FixedUpdate()
    {
       rb.velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Limit")
        {
            if (sr.flipX == false)
            {
                sr.flipX = true;
                speed = -2;
            }
            else
            {
                sr.flipX = false;
                speed = 2;
            }
        }
    }
}
