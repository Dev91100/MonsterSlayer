using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int maxhealth = 100;
    private int currenthealth = 0;
    bool die = false;
   
    void Start()
    {
        currenthealth = maxhealth;
    }

    public void MonsterTakeDamage(int damage)
    {
        currenthealth -= damage;
        
        animator.SetTrigger("Hurt");

        if (currenthealth <= 0)
        {
            animator.SetBool("IsDead", true);
        }

    }

    public void DisableMonster()
    {
        
        Destroy(gameObject);
    }
    
}
