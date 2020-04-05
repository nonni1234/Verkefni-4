using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizMove = 0f;
    float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }
    public void OnCrouching(bool isCrouching) {
        animator.SetBool("isCrouching", isCrouching);
    }
    void Update() { // Fá movement input
        horizMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizMove));
    }

    void FixedUpdate() { // Hreyfa Character
        controller.Move(horizMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
