using UnityEngine;


//This script will control the monsters'attack
/* 
 *  The idea to create this script came from this video but the script is not found in the video
 *  Some of the fucntions are from the official unity website
    Brackeys, 2019 : MELEE COMBAT in Unity
    Available from: https://www.youtube.com/watch?v=sPiVz1k-fEs&list=LLH3a8ESny180HvT46FvAlAw&index=15
*/
public class Monster_Attack : MonoBehaviour
{
    public SpriteRenderer SR;                  // Reference to the object's sprite renderer
    public Transform attackpt;                 // The attack point where the monster will attack
    public float range = 0.5f;                 // The radius of the circle
    public LayerMask player;                   // A layer assigned to the player
    private float NextActionTime = 0.0f;       // The current time + the time to wait 
    public float period = 1f;                  // A variable to add with current time
    public AudioSource Bite;                   // monster bite sound

    void Update()
    {
        // Creates a circle at a position within certain range and detect a layer(the player)
        // Then store the data received in an array(hitplayer)
        // It takes as parameter a point, a radius and a layer and store the data received in an array(hitenemies)

        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpt.position, range, player);

        foreach (Collider2D player in hitplayer)            // For each data(we named it player here) that is in the array
        {
            //This is ensuring that the enemy moves towards the player while facing him
            //If in the x-axis the enemies position is greater than the player's
            if (transform.position.x > player.transform.position.x)
            {
                
                SR.flipX = true;                             //Then we flip x and call the walking script 
                GetComponent<Monster_Walking>().speed = -2f; //to change the direction in which the enemy is walking
            }
            else
            {
                //If the enemies position is less than the player's in the x axis
                //We do not flip and it moves at a speed of 2

                SR.flipX = false;
                GetComponent<Monster_Walking>().speed = 2f;
            }

            //This here will  make the enemy give damage each second instead of each frame

            if (Time.time > NextActionTime)                                //If current time is greater than current time + period(The time to wait before attacking again)
            {
                NextActionTime = Time.time + period;                       //Incrementing the next action time

                Bite.Play();                                               //PLaying a bite sound
                player.GetComponent<Knight_Combat>().PlayerTakeDamage(1);  //Giving damage to player by calling knight combat script
            }


        }

    }

    //This function just give a visual to the circle that has been created above
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpt.position, range);
    }
}