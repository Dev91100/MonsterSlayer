using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int maxhealth = 100;
    private int currenthealth = 0;
    private bool die = false;

    private int nextSceneToLoad;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        currenthealth = maxhealth;
    }

    public void MonsterTakeDamage(int damage)
    {
        currenthealth -= damage;

        animator.SetTrigger("Hurt");

        if (currenthealth <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    public void DisableMonster()
    {
        SceneManager.LoadScene(nextSceneToLoad);
        Destroy(gameObject);
    }
}