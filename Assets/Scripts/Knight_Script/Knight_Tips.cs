using UnityEngine;

public class Knight_Tips : MonoBehaviour
{
    public SpriteRenderer render;

    void Start()
    {
        this.render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.render.enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.render.enabled = false;
        }
    }


}
