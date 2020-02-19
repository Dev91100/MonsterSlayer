using UnityEngine;

public class Knight_Combat : Knight_Movement
{

    public Transform attackPoint;
    public LayerMask enemyLayers;

    protected bool attack = false;
    public float attackRange = 0.5f;



    void Update()
    {
        HandleInput();
    }


    void FixedUpdate()
    {
        Attack();
    }

    //Handles Keyboard Input for attacking animation
    protected void HandleInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            attack = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            attack = false;
        }
    }


    void Attack()
    {
        if (attack)
        {
            animator.SetTrigger("attack");
        }


        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
