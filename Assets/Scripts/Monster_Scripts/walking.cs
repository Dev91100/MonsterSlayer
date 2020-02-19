using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class walking : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float speed = 2;
    public Animator animator;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   //void FixedUpdate()
    //{
      // rb.velocity = Vector2.left * speed;
    //}

    void OnTriggerEnter2D(Collider2D col)
   {
       if (col.gameObject.tag == "Limit") 
       {
            animator.SetTrigger("detection");
              rb.velocity = Vector2.left * speed;
       }
        animator.SetTrigger("attack");
   }
   
}
