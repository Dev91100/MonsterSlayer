using UnityEngine;

public class Level_Spike : MonoBehaviour
{
    public Transform attackpt;
    public float range = 0.5f;
    public LayerMask player;
    private float NextActionTime = 0.0f;
    public float period = 1f;
    public int damage = 25;
    public float length;
    public float height;
    private float depth;

    void Update()
    {

        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpt.position, range, player);

        foreach (Collider2D player in hitplayer)
        {

            if (Time.time > NextActionTime)
            {
                NextActionTime = Time.time + period;


                player.GetComponent<Knight_Combat>().PlayerTakeDamage(damage);
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(attackpt.position,new Vector3(length,height,depth));
    }

}