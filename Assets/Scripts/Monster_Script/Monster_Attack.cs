using UnityEngine;

public class Monster_Attack : MonoBehaviour
{
    public SpriteRenderer SR;
    public Transform attackpt;
    public float range = 0.5f;
    public LayerMask player;
    private float NextActionTime = 0.0f;
    public float period = 1f;
    public AudioSource Bite;

    void Update()
    {
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpt.position, range, player);

        foreach (Collider2D player in hitplayer)
        {
            if (transform.position.x > player.transform.position.x)
            {
                SR.flipX = true;
                GetComponent<Monster_Walking>().speed = -2f;
            }
            else
            {
                SR.flipX = false;
                GetComponent<Monster_Walking>().speed = 2f;
            }

            if (Time.time > NextActionTime)
            {
                NextActionTime = Time.time + period;

                Bite.Play();
                player.GetComponent<Knight_Combat>().PlayerTakeDamage(1);
            }


        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpt.position, range);
    }
}