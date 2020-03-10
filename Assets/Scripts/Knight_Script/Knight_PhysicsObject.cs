using System.Collections.Generic;
using UnityEngine;

// This script controls the player's movement physics system

// This script is attached to Knight_Player

/* 
    Unity, 2017 : 2D Platformer Character Controller [online].
    Available from: https://www.youtube.com/watch?v=wGI2e3Dzk_w&list=PLX2vGYjWbI0SUWwVPCERK88Qw8hpjEGd8
*/

public class Knight_PhysicsObject : MonoBehaviour
{
    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f; // Allows the programmer to scale the gravity in the inspector

    protected Animator animator;
    protected Vector2 targetVelocity; // Controls the velocity of the player according to gravity
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16); // List of current active raycast contacts


    protected const float minMoveDistance = 0.001f; // Assigns a minimum value to control the distance covered by the player
    protected const float shellRadius = 0.01f; // Adds a padding around the player collider to prevent the player from passing inside another collider

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get and store a Rigidbody2D component
    }

    void Start()
    {
        contactFilter.useTriggers = false;                                              // Prevent collision checking against triggers
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));  // Use the default value for collision mask in unity to determine what layers to check collision against
        contactFilter.useLayerMask = true;                                              // Allows the use of layer mask
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;       // Use the default gravity value in unity to calculate velocity
        velocity.x = targetVelocity.x;

        grounded = false;                                                       // grounded = false until a collision is registered

        Vector2 deltaPosition = velocity * Time.deltaTime;                      // Determine where the next position of the player will be

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);                                                  // Call the function movement

        move = Vector2.up * deltaPosition.y;                                    // Apply movement in the y axis

        Movement(move, true);                                                   // Call the function movement
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        // Use the magnitude of the move Vector 2 to prevent the player from constantly checking collsion

        if (distance > minMoveDistance) // If the distance coovered by the player is greater than the minimum move distance
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius); // Cast collider shape and store the results in the hitBuffer array

            // Clears hit buffer list to be able to add new data

            hitBufferList.Clear();

            // Loop over hitBufferList to take the raycast2D objects

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            // Loop over hitBufferList to determine the angle of the object's collider by checking the normal of each raycast object

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;

                // Determine if the player is grounded or not by checking the angle at which the player is colliding with a collider

                if (currentNormal.y > minGroundNormalY) 
                {
                    grounded = true;
                    if (yMovement) // If player is moving along the y axis
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal); // Calculate the dot product of velocity and currentNormal
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }

        rb2d.position = rb2d.position + move.normalized * distance; // Sets rb2d's position
    }
}
