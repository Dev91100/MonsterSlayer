using UnityEngine;

//This Script will control the monsters' health and damage taken

/* 
    Brackeys, 2019 : MELEE COMBAT in Unity
    Available from: https://www.youtube.com/watch?v=sPiVz1k-fEs&list=LLH3a8ESny180HvT46FvAlAw&index=15
*/

public class Monster_EnemyState : Monster_Loot
{
    public Rigidbody2D rb;
    public Animator animator;
    public int maxhealth = 100;
    private int currenthealth = 0;
    bool die = false;
    public AudioSource hurtsound;
    public AudioSource deadsound;

    public float xAmount = 0.1f;
    public float yAmount = 0.1f;

    void Start()
    {
        currenthealth = maxhealth;                           //the health of the player is assigned
    }

    public void EnemyTakeDamage(int damage)                  //This function takes in the damage taken by the player
    {
        if (die)                                             //If the player dies then return before anything happens
            return;
        currenthealth -= damage;                             //Substracting the damage from the health of the player
        hurtsound.Play();                                   
        animator.SetTrigger("Hurt");                         //Play hurt animation

        if (currenthealth <= 0)                              //If health is below of equal to zero then player dies
        {
            monsterLoot(xAmount, yAmount);

            die = true;

            deadsound.Play();                               //Death sound
            animator.SetBool("IsDead", true);               //play Death animation

        }

    }
    //When the monster dies in the animation an event is added to as to call these public fucntions
    public void DisableAttack()                                //This function will disable the ability of the monster to attack                         
    {
        GetComponent<Monster_Walking>().speed = 0;             //The speed is put to zero so that the monster stops
        GetComponent<Monster_Attack>().enabled = false;        //disable the attack script
    }
    public void DisableMonster()                               //This fucntion disables the monster
    {
        Destroy(gameObject);                                   //Destroys the Game Object(The Monster)
    }
}
