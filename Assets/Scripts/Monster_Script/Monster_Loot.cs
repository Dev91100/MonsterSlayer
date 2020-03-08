using UnityEngine;

public class Monster_Loot : MonoBehaviour
{
    public Rigidbody2D[] rb2D;
    public float thrust = 500f;
    public GameObject[] loots;
    public GameObject parent;

    public void monsterLoot(float xAmount, float yAmount)
    {
            Vector2 m_force = new Vector2(xAmount, yAmount) * thrust;
            for (int i = 0; i < loots.Length; i++)
            {
                loots[i].transform.parent = parent.transform;
                loots[i].SetActive(true);
            }
            for (int i = 0; i < loots.Length; i++)
            {
                rb2D[i].AddForce(m_force);
            }
    }
}
