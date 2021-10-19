using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public bool IsCrouching = false;
    
    
    

    // Update is called once per frame
    private void Awake()
    {        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        
        if (Input.GetButtonDown("Crouch")) IsCrouching = true;
        else if (Input.GetButtonUp("Crouch")) IsCrouching = false;
        
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
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, IsCrouching, jump);
        animator.SetBool("IsCrouching", IsCrouching);
        jump = false;
        
    }
}
