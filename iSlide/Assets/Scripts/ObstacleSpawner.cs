using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;
    private Vector2 spawnLocation;
    private int spawnPick;
    private float spawnPause;
    private float xSpawnPosition;


    void Start()
    {
        StartCoroutine("SpawnHorizontalObstacle");
    }
    
    IEnumerator SpawnHorizontalObstacle()
    {
        while(true)
        {
            spawnLocation = new Vector2(13, -3.95f);
            spawnPause = Random.Range(3,5);
            yield return new WaitForSeconds(spawnPause);

            spawnPick = Random.Range(0, 2);
            Instantiate(obstacle[spawnPick], spawnLocation, Quaternion.identity);
        }
    }

    IEnumerator SpawnVerticalObstacle()
    {
        while(true)
        {
            xSpawnPosition = Random.Range(-12, 12);
            spawnLocation = new Vector2(xSpawnPosition, -9);

            spawnPause = 0.5f;
            yield return new WaitForSeconds(spawnPause);

            Instantiate(obstacle[2], spawnLocation, Quaternion.identity);
        }
    }
}
