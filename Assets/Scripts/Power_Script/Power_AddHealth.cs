using UnityEngine;

public class Power_AddHealth : MonoBehaviour
{
    public GameObject heartParticle;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(heartParticle, col.transform.position, Quaternion.identity);
            Knight_SoundManager.PlaySound("Power_Heart");

            if (Knight_Combat.currenthealth < 4)
            {
                Knight_Combat.currenthealth += 1;
            }

            Destroy(gameObject);
        }
    }
}
