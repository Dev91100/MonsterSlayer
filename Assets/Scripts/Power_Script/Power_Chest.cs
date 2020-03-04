using UnityEngine;

// This script controls how the Chest Object reacts when the player hits it with the sword.

// This script is attached to Power_Chest

public class Power_Chest : MonoBehaviour
{
    public Animator animator;

    public void OpenChest() 
    {
        animator.SetTrigger("Open"); //  Activates trigger for chest open animation
        Knight_SoundManager.PlaySound("Power_ChestOpen"); // Activates sound for opening chest
    }

}
