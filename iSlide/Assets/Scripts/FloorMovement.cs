using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public bool moveFloorUp = false;
    private GameObject gameManager;
    private SceneSwitcher sceneSwitcher;
    private int moveSpeed = 9;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        sceneSwitcher = gameManager.GetComponent<SceneSwitcher>();
    }

    void Update()
    {
        moveFloorUp = sceneSwitcher.moveFloorUp;
        print("moveFloorUp is " + moveFloorUp);

        if(moveFloorUp && transform.position.y > -5.25f)
        {
            print("Boundary hit");
            sceneSwitcher.moveFloorUp = false;
            moveFloorUp = false;
        }
    }

    void FixedUpdate()
    {
        if(moveFloorUp)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }        
    }
}
