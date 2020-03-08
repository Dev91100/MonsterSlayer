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
    public static bool die = false;
    public Rigidbody2D rb1;

    // Health UI
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Spawn coins and hearts force in x and y axis
    public float xAmount = 0.1f;
    public float yAmount = 0.1f;

    // Players attack rate
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //public Knight_PhysicsObject NewPhysics;

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
                Knight_SoundManager.PlaySound("Knight_Sword1"); // Plays sword sound effect
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

    // This function controls the players health UI

    public void heartSystem(int health)
    {
        // Prevents the amount of heart displayed from being greater than the amount of health of the player
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            // Controls which type of heart to display depending of the amount of health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Controls amount of hearts to display in the UI
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
        //NewPhysics.enabled = false;
        GetComponent<Knight_Movement>().enabled = false;
        this.enabled = false;

        Invoke("DisableCol", 1f);
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
            createDust(); // Creates dust particle when player swing sword only if player is on the ground
        }

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenemies)
        {
            Monster_EnemyState enemy1 = enemy.GetComponent<Monster_EnemyState>();
            if (enemy1 != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                enemy1.EnemyTakeDamage(50);
                return;
            }

            Monster_Enemies enemy2 = enemy.GetComponent<Monster_Enemies>();
            if (enemy2 != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                enemy2.TakeDamage(20);
            }

            Monster_Flying enemy3 = enemy.GetComponent<Monster_Flying>();
            if(enemy3 != null) 
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Activates Camera Shake from Knight_CameraShake script
                enemy3.TakeDamageFlyMonster(25);
            }


            Knight_Barrel Barrel = enemy.GetComponent<Knight_Barrel>();
            if (Barrel != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Activates Camera Shake from Knight_CameraShake script
                Barrel.BreakBarrel(xAmount, yAmount);               // Breaks Barrel and spawn coins and hearts from Knight_Barrel script
            }

            Power_Chest Chest = enemy.GetComponent<Power_Chest>();
            if (Chest != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Activates Camera Shake from Knight_CameraShake script
                Chest.OpenChest(xAmount, yAmount);                  // Opens chest and spawn coins and hearts from Power_Chest script
            }

            Knight_Pot Pot = enemy.GetComponent<Knight_Pot>();
            if (Pot != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Activates Camera Shake from Knight_CameraShake script
                Pot.BreakPot(xAmount, yAmount);                     // Breaks Barrel and spawn coins and hearts from Knight_Pot script
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
