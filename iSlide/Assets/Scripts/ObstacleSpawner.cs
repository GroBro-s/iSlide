using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int spawnPatternChooser;
    public GameObject[] obstacle;
    private int spawnPick;
    private Vector2 spawnLocation;
    public float spawnHeight;
    private float spawnWidth;
    private float spawnPause;


    void Start()
    {
        StartCoroutine("spawnObstacle");
    }

    void Update()
    {
        spawnLocation = new Vector2(13, spawnHeight);        
    }
    
    IEnumerator spawnObstacle()
    {
        while(true)
        {
            spawnPause = Random.Range(5,10);
            spawnPick = Random.Range(0, 2);
            print(spawnPick);

            Instantiate(obstacle[spawnPick], spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(spawnPause);
        }
    }
}
