using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
		{
            jump = true;
            animator.SetBool("IsJump", true);
		}
        if (Input.GetButtonDown("Crouch"))
		{
            crouch = true;
            animator.SetBool("IsCrouch", true);

		} else if (Input.GetButtonUp("Crouch"))
		{
            crouch = false;
            animator.SetBool("IsCrouch", false);
		}

    }

    public void OnLanding ()
	{
        animator.SetBool("IsJump", false);
	}
    // bbz ka čia pridirbau 
    //public void OnCrouch (bool isCrouch)
	//{
    //    animator.SetBool("IsCrouch", isCrouch);
	//}
    
    void FixedUpdate ()
	{
        // Judejimas zmogeliuko
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
	}
    
}
