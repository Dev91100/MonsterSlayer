using UnityEngine;

public class Knight_Barrel : MonoBehaviour
{
    public Animator animator;

    public void OpenBox()
    {
        animator.SetTrigger("open");
        Destroy(gameObject, 1f);
        return;
    }
}
