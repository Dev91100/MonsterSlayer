using UnityEngine;

// This script controls the Fireball Object's direction, speed and lifetime 

// This script is attached to Boss_FireBall

public class Dragon_Fireball_Behaviour : MonoBehaviour
{
    public float Dragon_Fireball_speed;
    public float Dragon_Fireball_Lifetime;
    public GameObject destroyEffect;

    private void Update()
    {
        // This if statement tests if the dragon is moving
        if (Dragon_Pathfinding.x >= 0.00f || Dragon_Pathfinding.x <= 0.00f)
        {
            transform.Translate(transform.up * Dragon_Fireball_speed * Time.deltaTime); // Moves the fireball downwards
            transform.eulerAngles = new Vector3(0, 0, -90); // Rotates the fireball to face downwards
        }
    }

    // This function destroys the object Boss_FireBall
    void DestroyProjectile()
    {
        Destroy(gameObject, Dragon_Fireball_Lifetime);
    }
}
