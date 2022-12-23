using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCollectable : MonoBehaviour
{
    private int moveSpeed = 11;
    private Rigidbody2D rb;
    private bool upgradeHorizontalMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        if (transform.position.x < -12 || transform.position.y > 30)
        {
            DestroyUpgrade();
        }
    }

    void FixedUpdate()
    {
        if(upgradeHorizontalMove)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);           
        }

        if(upgradeHorizontalMove == false)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            DestroyUpgrade();
            print("You've collected an upgrade!");            
        }
    }

    void DestroyUpgrade()
    {
        Destroy(gameObject);
    }
}
