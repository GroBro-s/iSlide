using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    public GameObject upgrade;
    private Vector2 spawnLocation;
    private float spawnPause = 1;
    private float spawnHeight;
    private float spawnWidth = 12;


    void Start()
    {
        StartCoroutine("SpawnUpgrade");
        spawnLocation = new Vector2(spawnWidth, -1);
    }

    IEnumerator SpawnUpgrade()
    {
        yield return new WaitForSeconds(spawnPause);
         
        while (true)
        {
            spawnPause = Random.Range(2, 5);
            spawnHeight = Random.Range(-2.5f, 3f);
            spawnLocation = new Vector2(spawnWidth, spawnHeight);

            Instantiate(upgrade, spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(spawnPause);
        }
    }
}
