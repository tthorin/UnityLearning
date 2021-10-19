using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    Rigidbody2D body;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    Vector2 velocity;
    

    // Update is called once per frame
    private void Awake()
    {        
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        velocity = body.velocity;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch")) crouch = true;
        else if (Input.GetButtonUp("Crouch")) crouch = false;
        //if (horizontalMove > 0 || horizontalMove < 0) animator.SetBool("IsMoving", true);
        if(Input.GetButton("Horizontal")) animator.SetBool("IsMoving", true);
        else animator.SetBool("IsMoving", false);
        
        
        if (Input.GetButton("Fire1")) animator.SetTrigger("Attack");
        if (Input.GetButtonUp("Fire1")) animator.ResetTrigger("Attack");
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        animator.SetBool("IsCrouching", crouch);
        jump = false;
        
    }
}
