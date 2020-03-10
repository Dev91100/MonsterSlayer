using UnityEngine;

// This script makes objects spawn with a defined amount of force

// This script is used in the script Monster_EnemyState and Monster_Flying

public class Monster_Loot : MonoBehaviour
{
    public Rigidbody2D[] rb2D;
    public float thrust = 500f;
    public GameObject[] loots;
    public GameObject parent;

    public void monsterLoot(float xAmount, float yAmount)
    {
        Vector2 m_force = new Vector2(xAmount, yAmount) * thrust;   // This determines the amount of force to apply to the rigidbody
        
        // This for loop activates the sprite renderer and change the parent of all objects in the loop
        for (int i = 0; i < loots.Length; i++)
        {
            loots[i].transform.parent = parent.transform;
            loots[i].SetActive(true);
        }

        // This for loop applies a force to all objects in the loop
        for (int i = 0; i < loots.Length; i++)
        {
            rb2D[i].AddForce(m_force);
        }
    }
}
