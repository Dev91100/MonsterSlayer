using UnityEngine;

public class Power_ChestLoot : MonoBehaviour
{
    public SpriteRenderer render;
    public Rigidbody2D rb2D;

    public void ChestLoot()
    {
            rb2D.simulated = true;
            render.enabled = true;
    }

}
