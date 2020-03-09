using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
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
        if (die)                                   
            return;
        currenthealth -= damage;                    
        
        animator.SetTrigger("Hurt");                

        if (currenthealth <= 0)                     
        {
            die = true;
                
            animator.SetBool("IsDead", true);      

        }

    }

    
    //public void DisableAttack()                                                         
    //{
                    
    //    GetComponent<Monster_Attack>().enabled = false;        
    //}
    public void DisableMonster()                               
    {
        Destroy(gameObject);                                   
    }
}