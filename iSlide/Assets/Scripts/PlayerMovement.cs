using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded = false;
    private Rigidbody2D rb;
    public float jumpHeight;
    //private float verticalMoveInput;

    //public Joystick joystick;
    //private float horizontalMove, verticalMove;
    [SerializeField]
    //private float runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //input player
        //horizontalMove = joystick.Horizontal;
        //verticalMove = joystick.Vertical;
    }

    void FixedUpdate()
    {
        //output player
        //transform.Translate(horizontalMove * runSpeed * Time.deltaTime, verticalMove * runSpeed * Time.deltaTime, 0);
    }

    /*void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        rb.Velocity = new Vector2(VerticalMoveInput)
    }*/
    public void Jump()
    {
        if(isGrounded)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpHeight;
            print("Jump");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            print("Crashed");
            isGrounded = true; 
        }

    }
}
        /*Vector2 move = new Vector2(0, 3);
        transform.Translate(move);*/