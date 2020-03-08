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

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float xAmount = 0.1f;
    public float yAmount = 0.1f;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //A reference to the custom physics
    public Knight_PhysicsObject NewPhysics;

    //MonsterDmage
    int CommonEnemies = 50;
    int HeavyEnemies = 20;
    int FlyingEnemies = 25;

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

    //This Function will take any damage that the player receives through its parameter
    public void PlayerTakeDamage(int damage)
    {
        //If the player dies then we return before anything happens
        if (die)
        {
            return;
        }

        //Subtracting the damage taken to the current health of the player
        currenthealth -= damage;

        //Triggers a hurt animation
        animator.SetTrigger("hurt");
        Knight_SoundManager.PlaySound("Knight_Hurt"); // Activates sound for Hurt animation

        //If health is <= 0 then call a function
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

    //This function will be called when the player dies
    public void Die()
    {
        hearts[0].sprite = emptyHeart;
        animator.SetBool("isDead", true);

        //These are the things that will be disabled so that monsters cannot interact with the player

        SetTransformX();              // the player will move backwards
        NewPhysics.enabled = false;   // The custom physic will be disabled so as to let the player float
        GetComponent<Knight_Movement>().enabled = false;  //Disables the movement of the player
        this.enabled = false;         // Disable this script

        //This will delay the time to disable the collider just for proper animation
        Invoke("DisableCol", 1f);
    }

    void SetTransformX()
    {
        //Moves the player when called
        transform.position = new Vector3(((this.transform.position.x) - 3), transform.position.y, transform.position.z);
    }

    void DisableCol()
    {
        //Disables the collider on call
        GetComponent<Collider2D>().enabled = false;
    }

    //This function is called when attacking 
    void Attack()
    {
        animator.SetTrigger("Attack");   //attack Animation 
        if (grounded)
        {
            createDust();
        }

        // This will create a circle that will detect a layer(which will be the enemy)
        // It takes as parameter a point, a radius and a layer and store the data received in an array(hitenemies)
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // For each data(we named it enemy here) that is in the array
        foreach (Collider2D enemy in hitenemies)
        {
            Monster_EnemyState enemy1 = enemy.GetComponent<Monster_EnemyState>();  // assigning a script's component in a variable

            if (enemy1 != null)                                                   // if this variable is not null then
            {
                enemy1.EnemyTakeDamage(CommonEnemies);                            // Give damage to that layer by calling its damage function and giving it a parameter
                return;
            }

            Monster_Enemies enemy2 = enemy.GetComponent<Monster_Enemies>();      //assigning another script's component in a variable 

            if (enemy2 != null)                                                  //if this variable is not null then 
            {
                enemy2.TakeDamage(HeavyEnemies);                                 //Give damage to that layer by calling its damage function and giving it a parameter
            }

            Monster_Flying enemy3 = enemy.GetComponent<Monster_Flying>();        //assigning another script's component in a variable 

            if (enemy3 != null)                                                 //if this variable is not null then
            {
                enemy3.TakeDamageFlyMonster(FlyingEnemies);                     //Give damage to that layer by calling its damage function and giving it a parameter
            }


            Knight_Barrel Barrel = enemy.GetComponent<Knight_Barrel>();
            if (Barrel != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Barrel.BreakBarrel(xAmount, yAmount);               // Reference to Knight_Barrel script
            }

            Power_Chest Chest = enemy.GetComponent<Power_Chest>();
            if (Chest != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Chest.OpenChest(xAmount, yAmount);                  // Reference to Knight_Barrel script
            }

            Knight_Pot Pot = enemy.GetComponent<Knight_Pot>();
            if (Pot != null)
            {
                camanimator.enabled = false;                        // Disable the Main Camera's Cinemachine Brain
                cam.enabled = false;                                // Disable the Main Camera's Animator
                Knight_CameraShake.instance.startShake(.1f, .2f);   // Reference to Knight_CameraShake script
                Pot.BreakPot(xAmount, yAmount);                     // Reference to Knight_Pot script
            }
        }
    }

    //This function will just draw the the circle that we created above so that we can get a visual
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
