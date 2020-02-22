using UnityEngine;

public class Knight_Barrel : MonoBehaviour
{
    public Animator animator;

    public void BreakBarrel()
    {
        animator.SetTrigger("break");
        Knight_SoundManager.PlaySound("Knight_Barrel");
        Destroy(gameObject, .5f);
        return;
    }
}
