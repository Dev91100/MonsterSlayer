using UnityEngine;
using Cinemachine;

// This script controls the player's movement system

// This script is attached to Knight_Player

/* 
    Unity, 2017 : 2D Platformer Character Controller
    Available from: https://www.youtube.com/watch?v=wGI2e3Dzk_w&list=PLX2vGYjWbI0SUWwVPCERK88Qw8hpjEGd8
*/


public class Knight_Movement : Knight_PhysicsObject
{
    public CinemachineBrain cam;
    public Animator camanimator;

    public ParticleSystem dust; // Allows the programmer to add a particle system in the inspector

    public float maxSpeed = 7; // Set the movement speed of the player
    public float jumpTakeOffSpeed = 7;  // Set the jump height of the player

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // This function check for keyboard input and update triggers for player animation

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (camanimator.enabled == true || cam.enabled ==true)  //Stops player from moving left or right when cinemachine brain and animator are disabled.
        {
            move.x = Input.GetAxis("Horizontal"); // Check if the player has pressed "A" or "D" on the keyboard and makes the player move left or right
        

            if (Input.GetKeyDown(KeyCode.Space) && grounded) // Check if the spacebar has been pressed
            {
                Knight_SoundManager.PlaySound("Knight_Jump2"); // Play sound effect when player jump
                velocity.y = jumpTakeOffSpeed;
                createDust();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (velocity.y > 0) // Check if player is moving upwards
                {
                    velocity.y = velocity.y * 0.5f; // Reduce player velocity by half when the player stop pressing the spacebar
                }
            }

            // Check which direction the player is moving and flip the sprite renderer accordingly

            if (move.x > 0.01f)
            {
                if (spriteRenderer.flipX == true)
                {
                    spriteRenderer.flipX = false;
                    if (grounded == true)
                    {
                        createDust(); // Activates the particle system
                    }
                }
            }
            else if (move.x < -0.01f)
            {
                if (spriteRenderer.flipX == false)
                {
                    spriteRenderer.flipX = true;
                    if (grounded == true)
                    {
                        createDust(); // Activates the particle system
                    }
                }
            }

            animator.SetBool("grounded", grounded);                             // Triggers grounded parameter in animation if player is grounded
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);   // Triggers velocityx parameter in animation if player is moving

            targetVelocity = move * maxSpeed; // Set the speed of the player
        }
    }

    // This function activates the particle system

        public void createDust()
    {
        dust.Play();
    }
}