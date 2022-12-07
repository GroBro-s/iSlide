using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded = false;
    private Rigidbody2D rb;
    public float jumpHeight;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Jump()
    {
        if(isGrounded)
        {
            isGrounded = false;
            animator.SetBool("IsJumping", false);
            rb.velocity = Vector2.up * jumpHeight;
            
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            animator.SetBool("IsJumping", true);
        }
        if(other.gameObject.tag == "Obstacle")
        {
            isGrounded = true;
            animator.SetBool("IsJumping", true);
        }
    }
}