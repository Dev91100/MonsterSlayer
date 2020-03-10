using UnityEngine;

// This script controls how health system of the player

// This script is attached to Power_Heart

public class Power_AddHealth : MonoBehaviour
{
    public GameObject heartParticle; // Enables the programmer to add a particle system in the inspector

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(heartParticle, col.transform.position, Quaternion.identity); // Activates the particle system
            Knight_SoundManager.PlaySound("Power_Heart"); // Plays the sound effect

            // This if statement checks if the players health is below 4 before incrementing it
            if (Knight_Combat.currenthealth < 4)
            {
                Knight_Combat.currenthealth += 1;
            }

            Destroy(gameObject);
        }
    }
}
