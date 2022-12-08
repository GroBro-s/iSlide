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
        StartCoroutine("SpawnObstacle");
    }

    void Update()
    {
        spawnLocation = new Vector2(13, spawnHeight);        
    }
    
    IEnumerator SpawnObstacle()
    {
        while(true)
        {
            spawnPause = Random.Range(2,5);
            yield return new WaitForSeconds(spawnPause);

            spawnPick = Random.Range(0, 2);
            Instantiate(obstacle[spawnPick], spawnLocation, Quaternion.identity);
        }
    }
}
