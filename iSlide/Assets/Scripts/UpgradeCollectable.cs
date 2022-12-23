using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCollectable : MonoBehaviour
{
    private int moveSpeed = 11;
    private Rigidbody2D rb;
    private bool tableScene;
    public GameObject gameManager;
    private SceneSwitcher sceneSwitcher;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        rb = GetComponent<Rigidbody2D>();
        sceneSwitcher = gameManager.GetComponent<SceneSwitcher>();
    }

    void Update()
    {
        if (transform.position.x < -12 || transform.position.y > 30)
        {
            DestroyUpgrade();
        }

        tableScene = sceneSwitcher.tableScene;
    }

    void FixedUpdate()
    {
        if(tableScene)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);           
        }

        if(tableScene == false)
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
