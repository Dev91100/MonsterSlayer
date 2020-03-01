using UnityEngine;

// This script controls how the Pot Object reacts when the player hits it with the sword.

// This script is attached to Knight_Pot

public class Knight_Pot : MonoBehaviour
{
    public Animator animator;

    public void BreakPot()
    {
        animator.SetTrigger("break"); //  Activates trigger for Pot destruction animation
        Knight_SoundManager.PlaySound("Knight_Pot"); // Activates sound for Pot destruction

        Destroy(gameObject, .5f); // Destroys the game object from the scene
        return;
    }
}
