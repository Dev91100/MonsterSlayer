using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemylayers;
    public int maxhealth = 200;
    public int currenthealth;
    public int AccCurrentHealth;
    public Rigidbody2D rb1;
    bool die = false;
    //public Transform temp;

    // Start is called before the first frame update
    void Start()
    {
        
        currenthealth = maxhealth;
      
    }

   
    public void PlayerTakeDamage(int damage)
    {
        if (die)
        {
            return;
        }
       
        currenthealth -= damage;
        animator.SetTrigger("PlayerHurt");

        if (currenthealth <= 0)
        {
            die = true;
            Die();
        }

    }
    void Die()
    {
        animator.SetBool("PlayerDead", true);
        animator.SetBool("deadcnfirm", true);

        SetTransformX();
        rb1.gravityScale = 0;
        this.enabled = false;

        Invoke("DisableCol", 1f);
        

    }



    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

       Collider2D[] hitenemies= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemylayers);

        foreach (Collider2D enemy in hitenemies) 
        {
            EnemyState enemy1 = enemy.GetComponent<EnemyState>();
            if(enemy1 != null)
            {
                enemy1.EnemyTakeDamage(50);
                return;
            }
            // else
            //{
           // use this comment code the the below one does not work or call me
            Enemies enemy2 = enemy.GetComponent<Enemies>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(20);
            }

            Monster_flying enemy3 = enemy.GetComponent<Monster_flying>();
            if (enemy3 != null)
            {
                enemy3.TakeDamageFlyMonster(20);
            }



            BoxScript box = enemy.GetComponent<BoxScript>();
            if (box != null)
            {
                box.openbox();
            }
            //enemy.GetComponent<Enemies>().TakeDamage(20);
            //return;
           // }
            
           // enemy.GetComponent<Enemies>().TakeDamage(20);
           
        }
      

    }
    void SetTransformX()
    {
        transform.position = new Vector3(((this.transform.position.x)-3), transform.position.y, transform.position.z);
    }
    void DisableCol() 
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
   
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
