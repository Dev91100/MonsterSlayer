using UnityEngine;

// This script controls how the Pot Object reacts when the player hits it with the sword.

// This script is attached to Knight_Pot

public class Knight_Pot : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D[] rb2D;
    public float thrust = 500f;
    public GameObject[] loots;

    public void BreakPot()
    {
        for (int i = 0; i < loots.Length; i++)
        {
            loots[i].SetActive(true);
        }
        for (int i = 0; i < loots.Length; i++)
        {
            rb2D[i].AddForce(transform.up * thrust);
        }

        animator.SetTrigger("break"); //  Activates trigger for Pot destruction animation
        Knight_SoundManager.PlaySound("Knight_Pot"); // Activates sound for Pot destruction

        Destroy(gameObject, .5f); // Destroys the game object from the scene
    }
}
