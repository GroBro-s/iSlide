using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private float horizontalMove, verticalMove;
    [SerializeField]
    private float runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //input player
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
    }

    void FixedUpdate()
    {
        //output player
        transform.Translate(horizontalMove * runSpeed * Time.deltaTime, verticalMove * runSpeed * Time.deltaTime, 0);
    }
}
