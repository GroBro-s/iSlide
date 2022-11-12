using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded = false;
    private Rigidbody2D rb;
    public float jumpHeight;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if(isGrounded)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpHeight;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = true; 
        }
    }
}