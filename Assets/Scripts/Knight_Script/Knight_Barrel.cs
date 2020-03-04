using UnityEngine;

// This script controls how the Barrel Object reacts when the player hits it with the sword.

// This script is attached to Knight_Barrel

public class Knight_Barrel : MonoBehaviour
{
    public Animator animator;

    public void BreakBarrel()
    {
        animator.SetTrigger("break"); //  Activates trigger for Barrel destruction animation
        Knight_SoundManager.PlaySound("Knight_Barrel"); // Activates sound for Barrel destruction

        Destroy(gameObject, .5f); // Destroys the game object from the scene
    }
}
