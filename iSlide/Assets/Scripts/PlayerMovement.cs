using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded = false;
    private Rigidbody2D rb;
    public float jumpHeight;
    public GameObject gameManager;
    private SceneSwitcher sceneSwitcher;
    private bool tableScene;
    public float sideSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
        sceneSwitcher = gameManager.GetComponent<SceneSwitcher>();     
    }

    void Update()
    {
        tableScene = sceneSwitcher.tableScene;
    }

    public void Move()
    {

    }
    
    public void Jump()
    {
        
        if(isGrounded && tableScene)
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
        if(other.gameObject.tag == "Obstacle")
        {
            isGrounded = true;
        }
    }
}