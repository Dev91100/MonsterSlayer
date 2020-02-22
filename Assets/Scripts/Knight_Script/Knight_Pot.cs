using UnityEngine;

public class Knight_Pot : MonoBehaviour
{
    public Animator animator;

    public void BreakPot()
    {
        animator.SetTrigger("break");
        Knight_SoundManager.PlaySound("Knight_Pot");
        Destroy(gameObject, 1f);
        return;
    }
}
