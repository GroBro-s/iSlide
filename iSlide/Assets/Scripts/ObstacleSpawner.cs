using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int spawnPatternChooser;
    public GameObject obstacle;
    private Vector2 spawnLocation;
    private float spawnheight;
    private float spawnWidth;
    private float spawnPause;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator spawnObstacle()
    {
        yield return new WaitForSeconds(spawnPause);

        while(true)
        {
            spawnPatternChooser = Random.Range(0, 1);
        }
    }
}
