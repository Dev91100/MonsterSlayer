using UnityEngine;

// This script controls how the coin object reacts when the player collides with it

// This script is attached to Power_Coin

public class Power_Coin : MonoBehaviour
{
    public GameObject coinParticle;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(coinParticle, col.transform.position, Quaternion.identity); // Activates the particle system
            Knight_SoundManager.PlaySound("Power_Coin");    // Plays the sound effect
            Power_ScoreTextScript.coinAmount += 1;  // Increments the counter by 1
            Destroy(gameObject);
        }
    }

}
