using UnityEngine;

// This script controls how the Chest Object reacts when the player hits it with the sword.

// This script is attached to Power_Chest

public class Power_Chest : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D[] rb2D;
    public float thrust = 500f;
    public GameObject[] loots;
    private BoxCollider2D Bcol2D;

    private void Start()
    {
        Bcol2D = GetComponent<BoxCollider2D>();
    }

    public void OpenChest(float xAmount, float yAmount)
    {
        Vector2 m_force = new Vector2 (xAmount, yAmount) * thrust;
            for (int i = 0; i < loots.Length; i++)
            {
                loots[i].SetActive(true);
            }
            for (int i = 0; i < loots.Length; i++)
            {
                rb2D[i].AddForce(m_force);
            }
            
        animator.SetTrigger("Open"); //  Activates trigger for chest open animation
        Knight_SoundManager.PlaySound("Power_ChestOpen"); // Activates sound for opening chest       
        Bcol2D.enabled = false;
    }

}
