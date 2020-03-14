using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the health of the dragon and switch to the next scene once the dragon is dead

// This script is attached to Boss_RedDragron

public class Boss_Health : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int maxhealth = 100;
    private int currenthealth = 0;

    private int nextSceneToLoad;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        currenthealth = maxhealth;
    }

    // This function deals damage to the dragon and triggers the "Hurt" & "IsDead" animation

    public void MonsterTakeDamage(int damage)
    {
        currenthealth -= damage;

        animator.SetTrigger("Hurt");

        if (currenthealth <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    // This function destroys the dragon object and switch to the next scene

    public void DisableMonster()
    {
        Power_ScoreTextScript.coinAmount = 0;   // Resets the coin counter to 0
        SceneManager.LoadScene(nextSceneToLoad);    // Loads next scene
        Destroy(gameObject);
    }
}