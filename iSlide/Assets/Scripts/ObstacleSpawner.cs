using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;
    private Vector2 spawnLocation;
    private int spawnPick;
    private float spawnPause;


    void Start()
    {
        StartCoroutine("SpawnHorizontalObstacle");
    }
    
    IEnumerator SpawnHorizontalObstacle()
    {
        while(true)
        {
            spawnLocation = new Vector2(13, -3.95f);
            spawnPause = Random.Range(4,7);
            yield return new WaitForSeconds(spawnPause);

            spawnPick = Random.Range(0, 2);
            Instantiate(obstacle[spawnPick], spawnLocation, Quaternion.identity);
        }
    }

    IEnumerator SpawnVerticalObstacle()
    {
        while(true)
        {
            spawnPause = Random.Range(2,5);
            spawnLocation = new Vector2(0, -9);
            spawnPause = Random.Range(4,7);
            yield return new WaitForSeconds(spawnPause);

            spawnPick = Random.Range(0, 2);
            Instantiate(obstacle[spawnPick], spawnLocation, Quaternion.identity);
        }
    }
}
