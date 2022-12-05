using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private int moveSpeed = 11;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < -30)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
