using UnityEngine;

public class Monster_Enemies : MonoBehaviour
{
    public float range = 1f;
    public Transform EnemyAtkP;
    public int maxhealth = 100;
    int currenthealth;
    public Animator animator;
    public Rigidbody2D rb;
    public float attackRange = 4f;
    public LayerMask player;
    public float speed = 2f;
    public float PlayerPosition = 2f;
    bool die = false;
    public AudioSource hurtsound;
    public AudioSource swordsound;
    public AudioSource deathsound;
    bool flip = false;

    // private float NextActionTime = 0.0f;
    //public float period = 1f;
    // public PlayerCombat playerhealth;


    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;

    }

    public void TakeDamage(int damage)
    {
        // if (die == true)
        //{
        //  return;
        //}
        currenthealth -= damage;
        animator.SetTrigger("Hurt");
        hurtsound.Play();

        if (currenthealth <= 0)
        {

            die = true;

            Die();
        }

    }
    public void Die()
    {
        deathsound.Play();
        animator.SetBool("IsDead", true);


        GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 0;
        this.enabled = false;
        // GetComponent<Collider2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] folplayer = Physics2D.OverlapCircleAll(transform.position, attackRange, player);
        animator.SetBool("run", false);
        foreach (Collider2D player in folplayer)
        {
            if ((transform.position.x < player.transform.position.x) && flip == false)
            {
                transform.Rotate(0f, 180f, 0f);
                flip = true;
            }

            if ((transform.position.x > player.transform.position.x) && flip == true)
            {
                transform.Rotate(0f, -180f, 0f);
                flip = false;
            }

            // animator.SetBool("run", false);
            if (Vector2.Distance(transform.position, player.transform.position) > PlayerPosition)
            {

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);

                animator.SetBool("run", true);

            }
            else
            {
                animator.SetBool("attack", true);
            }



        }
    }
    public void attack()
    {

        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(EnemyAtkP.position, range, player);
        
        animator.SetBool("attack", false);

        foreach (Collider2D player in hitplayer)
        {
            animator.SetBool("attack", true);
            swordsound.Play();
            player.GetComponent<Knight_Combat>().PlayerTakeDamage(1);

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(EnemyAtkP.position, range);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}