using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    public GameObject upgrade;
    private Vector2 spawnLocation;
    private float spawnPause;
    private float spawnHeight;
    private float spawnWidth;


    void Start()
    {
        StartCoroutine("SpawnHorizontalUpgrade");
    }

    IEnumerator SpawnHorizontalUpgrade()
    { 
        while (true)
        {
            spawnPause = Random.Range(2, 5);
            yield return new WaitForSeconds(spawnPause);

            spawnHeight = Random.Range(-3.1f, 3);
            spawnLocation = new Vector2(12, spawnHeight);
            Instantiate(upgrade, spawnLocation, Quaternion.identity);
        }
    }

    IEnumerator SpawnVerticalUpgrade()
    {
        while (true)
        {
            spawnPause = Random.Range(2, 5);
            yield return new WaitForSeconds(spawnPause);
            spawnWidth = Random.Range(-11, 11);
            spawnLocation = new Vector2(spawnWidth, -7);
            Instantiate(upgrade, spawnLocation, Quaternion.identity);
        }
    }
}
