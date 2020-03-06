using UnityEngine;

// This script controls how the Barrel Object reacts when the player hits it with the sword.

// This script is attached to Knight_Barrel

public class Knight_Barrel : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D[] rb2D;
    public float thrust = 500f;
    public GameObject[] loots;

    public void BreakBarrel(float xAmount, float yAmount)
    {
        Vector2 m_force = new Vector2(xAmount, yAmount) * thrust;

        for (int i = 0; i < loots.Length; i++)
        {
            loots[i].SetActive(true);
        }
        for (int i = 0; i < loots.Length; i++)
        {
            rb2D[i].AddForce(m_force);
        }

        animator.SetTrigger("break"); //  Activates trigger for Barrel destruction animation
        Knight_SoundManager.PlaySound("Knight_Barrel"); // Activates sound for Barrel destruction
        Destroy(gameObject, .5f); // Destroys the game object from the scene
    }
}
