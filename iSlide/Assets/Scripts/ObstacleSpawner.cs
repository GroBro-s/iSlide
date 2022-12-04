using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int spawnPatternChooser;
    public GameObject obstacle;
    private Vector2 spawnLocation = new Vector2(13,0);
    private float spawnheight;
    private float spawnWidth;
    private float spawnPause;


    void Start()
    {
        StartCoroutine("spawnObstacle");
    }

    IEnumerator spawnObstacle()
    {
        while(true)
        {
            spawnPause = Random.Range(5,10);

            Instantiate(obstacle, spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(spawnPause);
        }
    }
}
