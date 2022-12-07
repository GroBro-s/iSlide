using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private GameObject gameManager;
    private ObstacleSpawner obstacleSpawner;
    private UpgradeSpawner upgradeSpawner;
    [SerializeField] private GameObject backGround;
    private BackGroundScroll backGroundScroll;
    [SerializeField] private GameObject floor;
    private BackGroundScroll floorScroll;  
    public GameObject player;
    private PlayerMovement playerMovement;
    public bool tableScene;
    private int tableTime;
    private int moveSpeed;
    private bool floorSpawned;


    void Awake()
    {
        floorSpawned = true;
        gameManager = this.gameObject;
        obstacleSpawner = gameManager.GetComponent<ObstacleSpawner>();
        upgradeSpawner = gameManager.GetComponent<UpgradeSpawner>();
        playerMovement = player.GetComponent<PlayerMovement>();
        backGroundScroll = backGround.GetComponent<BackGroundScroll>();
        floorScroll = floor.GetComponent<BackGroundScroll>();
    }
    void Start()
    {
        StartCoroutine("SwitchToAir");
    }

    void FixedUpdate()
    {
        floor.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if(floorSpawned && floor.transform.position.x < -30)
        {
            Destroy(floor);
            floorSpawned = false;
        }
    }

    IEnumerator SwitchToAir()
    {
        tableTime = 2;
        yield return new WaitForSeconds(tableTime);
        tableScene = false;
        obstacleSpawner.StopCoroutine("SpawnObstacle");
        upgradeSpawner.StopCoroutine("SpawnUpgrade");

        yield return new WaitForSeconds(1);
        moveSpeed = 11;
        floorScroll.xVelocity = 0;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;

        yield return new WaitForSeconds(2);
        backGroundScroll.xVelocity = 0;
        backGroundScroll.yVelocity = -4;
    }
}
