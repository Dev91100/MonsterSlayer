using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    public SpriteRenderer SR;
    public Transform attackpt;
    public float range = 0.5f;
    public LayerMask player;
    private float NextActionTime = 0.0f;
    public float period = 1f;
    public float length;
    public float height;
    private float depth;

    private void Start()
    {
    }

    private void Update()
    {
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpt.position, range, player);

        foreach (Collider2D player in hitplayer)
        {
            if (Time.time > NextActionTime)
            {
                NextActionTime = Time.time + period;

                player.GetComponent<Knight_Combat>().PlayerTakeDamage(1);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(attackpt.position, new Vector3(length, height, depth));
    }
}