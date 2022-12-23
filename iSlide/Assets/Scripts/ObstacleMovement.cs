using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private int horizontalMoveSpeed = 11;
    private int verticalMoveSpeed = 11;
    public bool tableScene;
    private GameObject gameManager;


    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        tableScene = gameManager.GetComponent<SceneSwitcher>().tableScene;

        if (transform.position.x < -30 || transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if(tableScene)
        {
            transform.Translate(Vector3.left * horizontalMoveSpeed * Time.deltaTime);
        }

        if(tableScene == false)
        {
            transform.Translate(Vector3.up * verticalMoveSpeed * Time.deltaTime);            
        }
    }
}
