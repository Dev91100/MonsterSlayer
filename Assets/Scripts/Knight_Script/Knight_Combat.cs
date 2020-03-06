using UnityEngine;
using UnityEngine.UI;

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
    public int maxhealth = 4;
    public static int currenthealth;
    bool die = false;
    public Rigidbody2D rb1;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

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

        heartSystem(currenthealth);
    }


    public void PlayerTakeDamage(int damage)
    {
        if (die)
        {
            return;
        }
        currenthealth -= damage;

        animator.SetTrigger("hurt");
        Knight_SoundManager.PlaySound("Knight_Hurt"); // Activates sound for Hurt animation

        if (currenthealth <= 0)
        {
            die = true;
            Die();
        }
    }

    public void heartSystem(int health)
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Die()
    {
        hearts[0].sprite = emptyHeart;
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

            Enemies enemy2 = enemy.GetComponent<Enemies>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(20);
            }

            Knight_Barrel Barrel = enemy.GetComponent<Knight_Barrel>();
            if (Barrel != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Barrel.BreakBarrel();                                  // Reference to Knight_Barrel script
            }

            Power_Chest Chest = enemy.GetComponent<Power_Chest>();
            if (Chest != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Chest.OpenChest();                                  // Reference to Knight_Barrel script
            }

            Knight_Pot Pot = enemy.GetComponent<Knight_Pot>();
            if (Pot != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Pot.BreakPot();                                     // Reference to Knight_Pot script
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
