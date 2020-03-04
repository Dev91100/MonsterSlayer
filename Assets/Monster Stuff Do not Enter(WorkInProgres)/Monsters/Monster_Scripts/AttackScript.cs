using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public SpriteRenderer SR;
    public Transform attackpt;
    public float range = 0.5f;
    public LayerMask player;
    private float NextActionTime = 0.0f;
    public float period = 1f;
    public AudioSource Bite;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpt.position, range, player);

        foreach (Collider2D player in hitplayer)
        {
            if (transform.position.x > player.transform.position.x)
            {
                SR.flipX = true;
                GetComponent<WalkingRight>().speed = -2f;
            }
            else
            {
                SR.flipX = false;
                GetComponent<WalkingRight>().speed = 2f;
            }

            if (Time.time > NextActionTime)
            {
                NextActionTime = Time.time + period;

                Bite.Play();
                player.GetComponent<Knight_Combat>().PlayerTakeDamage(25);
            }


        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpt.position, range);
    }
}