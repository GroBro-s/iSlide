  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SceneSwitcher sceneSwitcher;
    private bool tableScene;
    private int sideSpeed = 15;
    private float jumpHeight = 15;
    private GameObject gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody2D>();  
        sceneSwitcher = gameManager.GetComponent<SceneSwitcher>();     
    }

    void Update()
    {
        tableScene = sceneSwitcher.tableScene;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = true; 
        }
        if(other.gameObject.tag == "Obstacle")
        {
            isGrounded = true;
        }
    }
    public void Jump()
    {
        if(isGrounded && tableScene)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpHeight;
        }
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
    }
}