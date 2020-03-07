using UnityEngine;

public class Monster_EnemyState : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int maxhealth = 100;
    private int currenthealth = 0;
    bool die = false;
    public AudioSource hurtsound;
    public AudioSource deadsound;

    // Start is called before the first frame update
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
