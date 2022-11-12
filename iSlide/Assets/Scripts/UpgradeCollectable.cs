using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCollectable : MonoBehaviour
{
    public int moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < -12)
        {
            DestroyUpgrade();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D()
    {
        DestroyUpgrade();
        print("You've collected an upgrade!");
    }

    void DestroyUpgrade()
    {
        Destroy(gameObject);
    }
}
