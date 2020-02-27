using UnityEngine;

public class Power_Coin : MonoBehaviour
{
    public GameObject coinParticle;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(coinParticle, col.transform.position, Quaternion.identity);
            Knight_SoundManager.PlaySound("Power_Coin");
            Destroy(gameObject);
        }
    }

}
