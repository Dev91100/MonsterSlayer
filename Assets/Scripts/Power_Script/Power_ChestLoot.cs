using UnityEngine;

public class Power_ChestLoot : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb2D;

    private void Start()
    {
        transform.position = new Vector3(0.0f, -2.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        ChestLoot();
    }

    public void ChestLoot()
    {
        rb2D.AddForce(transform.up * speed);
    }

}
