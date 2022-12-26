  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool movePlayerUp;
    private bool movePlayerLeft;
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

    //MoveLeft kan efficiënter. In plaats van de positie te resetten via de variabele kan de functie ook hergebruikt worden.

    void Update()
    {
        tableScene = sceneSwitcher.tableScene;

        if (movePlayerUp )
        {
            rb.velocity = new Vector2(0, 3);
        }

        if (movePlayerLeft)
        {
            rb.velocity = new Vector2(-10, 0);
        }

        if (transform.position.y > 3 && tableScene == false)
        {
            movePlayerUp = false;
			rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		}

        if (transform.position.x < -7 && tableScene)
        {
            movePlayerLeft = false;
			rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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

    public void ResetPlayerPosition()
    {
        if(tableScene == false)
        {
            movePlayerUp = true;
        }

        if(tableScene) 
        {
            movePlayerLeft = true;
        }
    }
}