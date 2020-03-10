using UnityEngine;
using UnityEngine.UI;

// This script controls the player's combat system

// This script is attached to Knight_Player

/*
    Brackeys, 2019 : MELEE COMBAT in Unity [online].
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

    // Health UI
    public int health;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Spawn coins and hearts with xAmount and yAmount of force in x and y axis
    public float xAmount = 0.1f;

    public float yAmount = 0.1f;

    // Players attack rate
    public float attackRate = 2f;

    private float nextAttackTime = 0f;

    //A reference to the custom physics
    public Knight_PhysicsObject NewPhysics;

    //MonsterDmage
    private int CommonEnemies = 50;

    private int HeavyEnemies = 20;
    private int FlyingEnemies = 25;

    private void Start()
    {
        currenthealth = maxhealth;
    }

    private void Update()
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

        // Keeps the heart UI of the player up to date with the player's currenthealth as parameter
        heartSystem(currenthealth);
    }

    //This function will take any damage that the player receives through its parameter
    public void PlayerTakeDamage(int damage)
    {
        currenthealth -= damage;       //Subtracting the damage taken to the current health of the player

        animator.SetTrigger("hurt");
        Knight_SoundManager.PlaySound("Knight_Hurt"); // Activates sound for Hurt animation

        if (currenthealth <= 0)
        {
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

    //This function will be called when the player dies

    public void Die()
    {
        hearts[0].sprite = emptyHeart; // Sets the last heart sprite to emptyHeart
        animator.SetBool("isDead", true);

        //These are the things that will be disabled so that monsters cannot interact with the player
        SetTransformX();                                          // The player will move backwards
        NewPhysics.enabled = false;                               // The custom physic will be disabled so as to let the player float
        GetComponent<Knight_Movement>().enabled = false;          // Disables the movement of the player
        this.enabled = false;                                     // Disable this script

        Invoke("DisableCol", 1f);                                 //This will delay the time to disable the collider just for proper animation
    }

    //This function will move the player when called
    private void SetTransformX()
    {
        transform.position = new Vector3(((this.transform.position.x) - 3), transform.position.y, transform.position.z);
    }

    //Disables the collider on call
    private void DisableCol()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    //This function is called when attacking
    private void Attack()
    {
        animator.SetTrigger("Attack");
        if (grounded)
        {
            createDust(); // Creates dust particle when player swing sword only if player is on the ground
        }

        // This will create a circle that will detect a layer(which will be the enemy)
        // It takes as parameter a point, a radius and a layer and store the data received in an array(hitenemies)
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // For each data(we named it enemy here) that is in the array
        foreach (Collider2D enemy in hitenemies)
        {
            Monster_EnemyState enemy1 = enemy.GetComponent<Monster_EnemyState>();       // assigning a script's component in a variable
            if (enemy1 != null)                                                         // if this variable is not null then
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                enemy1.EnemyTakeDamage(CommonEnemies);              // Give damage to that layer by calling its damage function and giving it a parameter
                return;
            }

            Monster_Enemies enemy2 = enemy.GetComponent<Monster_Enemies>();        //assigning another script's component in a variable
            if (enemy2 != null)                                                    //if this variable is not null then
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                enemy2.TakeDamage(HeavyEnemies);                    // Give damage to that layer by calling its damage function and giving it a parameter
            }

            Monster_Flying enemy3 = enemy.GetComponent<Monster_Flying>();        // Assigning another script's component in a variable
            if (enemy3 != null)                                                  // If this variable is not null then
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Activates Camera Shake from Knight_CameraShake script
                enemy3.TakeDamageFlyMonster(FlyingEnemies);         // Give damage to that layer by calling its damage function and giving it a parameter
            }

            Boss_Health enemy4 = enemy.GetComponent<Boss_Health>();
            if (enemy4 != null)
            {
                enemy4.MonsterTakeDamage(25);
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

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}