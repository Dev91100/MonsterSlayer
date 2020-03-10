using UnityEngine;

// This script controls how the Chest Object reacts when the player hits it with the sword.

// This script is attached to Power_Chest

public class Power_Chest : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D[] rb2D;  // Array to contain objects with a rigidbody attached
    public float thrust = 500f;
    public GameObject[] loots;  // Array to contain objects
    private BoxCollider2D Bcol2D;

    private void Start()
    {
        Bcol2D = GetComponent<BoxCollider2D>(); // Gets the object's Box Collider
    }

    public void OpenChest(float xAmount, float yAmount)
    {
        Vector2 m_force = new Vector2 (xAmount, yAmount) * thrust;  // This determines the amount of force to apply to the rigidbody

        // This for loop activates the sprite renderer of all objects in the loop
        for (int i = 0; i < loots.Length; i++)
        {
            loots[i].SetActive(true);
        }

        // This for loop applies a force to all objects in the loop
        for (int i = 0; i < loots.Length; i++)
        {
            rb2D[i].AddForce(m_force);
        }
            
        animator.SetTrigger("Open"); //  Activates trigger for chest open animation
        Knight_SoundManager.PlaySound("Power_ChestOpen"); // Activates sound for opening chest       
        Bcol2D.enabled = false; // Disables the chest's box collider to prevent the player from hitting it again
    }

}
