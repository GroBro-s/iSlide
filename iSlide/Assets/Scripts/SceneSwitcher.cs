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
    public GameObject verticalButton;
    public GameObject horizontalButtons;


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
        if(floorSpawned)
        {
            floor.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if(floor.transform.position.x < -30)
            {
                Destroy(floor);
                floorSpawned = false;
                moveSpeed = 0;
            }
        }
    }

    IEnumerator SwitchToAir()
    {
        tableTime = Random.Range(5,10);
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
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        verticalButton.SetActive(false);
        horizontalButtons.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        backGroundScroll.yVelocity = -4;
    }
}