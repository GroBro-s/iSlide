using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded = false;
    private Rigidbody2D rb;
    public float jumpHeight;
    //testPlayerSkin
    public Animator animator;
    public GameObject gameManager;
    private SceneSwitcher sceneSwitcher;
    private bool tableScene;
    private int sideSpeed = 15;
    private bool moveRight;
    private bool moveLeft;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
        sceneSwitcher = gameManager.GetComponent<SceneSwitcher>();     
    }
    //main

    void Update()
    {
        tableScene = sceneSwitcher.tableScene;
    }


    public void Jump()
    {
        if(isGrounded && tableScene)
        {
            isGrounded = false;
            animator.SetBool("IsJumping", false);
            rb.velocity = Vector2.up * jumpHeight;
            
        }
    }

 //testPlayerSkin
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }
    public void MoveRight()
    {
        rb.velocity = Vector2.right * sideSpeed;
    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.left * sideSpeed;
    }

    public void MoveStop()
    {
        rb.velocity = Vector2.zero;
    //main
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