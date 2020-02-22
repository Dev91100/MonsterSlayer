using UnityEngine;

public class Knight_Combat : Knight_Movement
{

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;

    //Health
    public int maxhealth = 100;
    public int currenthealth;
    bool die = false;
    public Rigidbody2D rb1;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //new attack
    //public LayerMask enemylayers;
    void Start()
    {
        currenthealth = maxhealth;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Knight_SoundManager.PlaySound("Knight_Sword1");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        if (die)
        {
            return;
        }
        currenthealth -= damage;
        animator.SetTrigger("hurt");

        if (currenthealth <= 0)
        {
            die = true;
            Die();
        }

    }
    void Die()
    {
        animator.SetBool("isDead", true);

        SetTransformX();
        rb1.gravityScale = 0;
        this.enabled = false;

        Invoke("DisableCol", 2f);
    }
    void SetTransformX()
    {
        transform.position = new Vector3(((this.transform.position.x) - 3), transform.position.y, transform.position.z);
    }
    void DisableCol()
    {
        GetComponent<Collider2D>().enabled = false;
        //  GetComponent<CircleCollider2D>().enabled = false;
    }


    void Attack()
    {
        animator.SetTrigger("Attack");
        if (grounded)
        {
            createDust();
        }

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenemies)
        {
            EnemyState enemy1 = enemy.GetComponent<EnemyState>();
            if (enemy1 != null)
            {
                enemy1.EnemyTakeDamage(50);
                return;
            }
            else
            {
                // use this comment code the the below one does not work or call me
                //Enemies enemy2 = enemy.GetComponent<Enemies>();
                //if (enemy2 != null)
                //{
                //    enemy2.TakeDamage(20);
                //}
                enemy.GetComponent<Enemies>().TakeDamage(20);
                return;
            }

            // enemy.GetComponent<Enemies>().TakeDamage(20);

        }


    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
