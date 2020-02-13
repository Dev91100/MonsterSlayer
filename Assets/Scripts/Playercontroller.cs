using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour { 

    public float Player_jumpForce;
    public float Player_Speed;
    private Rigidbody2D rb;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float JumpTime;
    public bool isJumping;
    private bool doubleJump;

    private Animator anim;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        //Jumping
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Z))
        {
            jumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * Player_jumpForce;
        }

        if (isGrounded == true)
        {
            doubleJump = false;
        }

        if (Input.GetKey(KeyCode.Z) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * Player_jumpForce;
                jumpTimeCounter *= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
        }

        if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.Z))
        {
            isJumping = true;
            doubleJump = true;
            isJumping = true;
            jumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * Player_jumpForce;
        }

       
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Player_Speed, rb.velocity.y);

        //Animation
                //Movement_Animation
        if (moveInput == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }



        
        //Movement
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }


}
