using UnityEngine;

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
        currenthealth = maxhealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        if (die)
            return;
        currenthealth -= damage;
        hurtsound.Play();
        animator.SetTrigger("Hurt");

        if (currenthealth <= 0)
        {
            monsterLoot(xAmount, yAmount);

            die = true;

            deadsound.Play();
            animator.SetBool("IsDead", true);

        }

    }
    public void DisableAttack()
    {
        GetComponent<Monster_Attack>().enabled = false;
        //animator.SetBool("IsDead", true);
    }
    public void DisableMonster()
    {
       // GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
