using UnityEngine;

// This script makes the dragon deal damage to the player when the latter collides with it

// This script is attached to Boss_CollideDamage

public class Boss_Attack : MonoBehaviour
{
    public Transform attackpt; // Sets a position for the collider object
    public float range = 0.5f; // Sets the range of the collider object
    public LayerMask player;
    private float NextActionTime = 0.0f;
    public float period = 1f;
    public int playerDamage = 1; // Amount of damage to deal to the player

    private void Update()
    {
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpt.position, range, player);

        foreach (Collider2D player in hitplayer)
        {
            if (Time.time > NextActionTime)
            {
                NextActionTime = Time.time + period;

                player.GetComponent<Knight_Combat>().PlayerTakeDamage(playerDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpt.position, range);
    }
}