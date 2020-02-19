using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40;
    float horizontalmove = 0;
    public Animator animator;
    
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, false);
    }
}
