using UnityEngine;

// This script enables or disables the player tips in Level_Level1

// This script is attached to Knight_TipsBox_Move, Knight_TipsBoxSpaceBar, Knight_TipsBoxLeftMouse

public class Knight_Tips : MonoBehaviour
{
    public SpriteRenderer render;

    void Start()
    {
        this.render = GetComponent<SpriteRenderer>(); // Get access to the sprite renderer
    }

    // If player enters the trigger zone, the sprite renderer is enabled

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.render.enabled = true;

        }
    }

    // If player exits the trigger zone, the sprite renderer is disabled

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.render.enabled = false;
        }
    }


}
