using UnityEngine;

// This script controls the player's combat system

// This script is attached to Knight_Player

/* 
    Brackeys, 2019 : MELEE COMBAT in Unity
    Available from: https://www.youtube.com/watch?v=sPiVz1k-fEs&list=LLH3a8ESny180HvT46FvAlAw&index=15
*/


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


    public GameObject heart1, heart2, heart3, heart4;
    //new attack
    //public LayerMask enemylayers;
    void Start()
    {
        currenthealth = maxhealth;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime) // Keeps track of the current time
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Knight_SoundManager.PlaySound("Knight_Sword1"); // Plays sound effect
                Attack();                                       // Reference to Attack function below
                nextAttackTime = Time.time + 1f / attackRate;   // Controls the attack rate of the player per second
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            camanimator.enabled = true; // Enables the Main Camera's Cinemachine Brain
            cam.enabled = true;         // Enables the Main Camera's animator
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

        if (currenthealth <= 75)
        {
            heart1.gameObject.SetActive(false);
        }

        else if (currenthealth <= 50)
        {
            heart2.gameObject.SetActive(false);
        }

        else if (currenthealth <= 50)
        {
            heart3.gameObject.SetActive(false);
        }

        if (currenthealth <= 0)
        {
            heart4.gameObject.SetActive(false);
            die = true;
            Die();
        }

    }
    public void Die()
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
            //else
            // {
            //use this comment code the the below one does not work or call me

            Enemies enemy2 = enemy.GetComponent<Enemies>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(20);
            }

            Knight_Barrel Box = enemy.GetComponent<Knight_Barrel>();
            if (Box != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Box.BreakBarrel();                                  // Reference to Knight_Barrel script
            }

            Knight_Pot Pot = enemy.GetComponent<Knight_Pot>();
            if (Pot != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Pot.BreakPot();                                     // Reference to Knight_Pot script
            }
            // enemy.GetComponent<Enemies>().TakeDamage(20);
            // return;
            //  }

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
