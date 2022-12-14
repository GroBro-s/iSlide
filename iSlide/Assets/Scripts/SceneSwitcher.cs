using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private ObstacleSpawner obstacleSpawner;
    private ObstacleMovement obstacleMovement;
    private UpgradeSpawner upgradeSpawner;
    [SerializeField] private GameObject backGround;
    private BackGroundScroll backGroundScroll;
    [SerializeField] private GameObject floor;
    private BackGroundScroll floorScroll;  
    private PlayerMovement playerMovement;
    private int tableTime;
    private int airTime;
    private int moveSpeed;
    private bool floorSpawned = true;
    private GameObject gameManager;
    private Rigidbody2D rb;
    public bool tableScene;
    public GameObject player;
    public GameObject verticalButton;
    public GameObject horizontalButtons;


    void Awake()
    {
        gameManager = this.gameObject;
        obstacleSpawner = gameManager.GetComponent<ObstacleSpawner>();
        obstacleMovement = gameManager.GetComponent<ObstacleMovement>();
        upgradeSpawner = gameManager.GetComponent<UpgradeSpawner>();
        playerMovement = player.GetComponent<PlayerMovement>();
        backGroundScroll = backGround.GetComponent<BackGroundScroll>();
        floorScroll = floor.GetComponent<BackGroundScroll>();
        rb = player.GetComponent<Rigidbody2D>();
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
        tableTime = Random.Range(10,20);
        yield return new WaitForSeconds(tableTime);

        obstacleSpawner.StopCoroutine("SpawnHorizontalObstacle");
        yield return new WaitForSeconds(3);

        tableScene = false;
        moveSpeed = 11;
        floorScroll.xVelocity = 0;
        yield return new WaitForSeconds(1);

        upgradeSpawner.StopCoroutine("SpawnHorizontalUpgrade");
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1);

        backGroundScroll.xVelocity = 0;
        yield return new WaitForSeconds(0.5f);

        verticalButton.SetActive(false);
        horizontalButtons.SetActive(true);
        backGroundScroll.yVelocity = -4;
        upgradeSpawner.StartCoroutine("SpawnVerticalUpgrade");
        obstacleSpawner.StartCoroutine("SpawnVerticalObstacle");
        StartCoroutine("SwitchToGround");
    }

    IEnumerator SwitchToGround()
    {
        airTime = Random.Range(10,20);
        yield return new WaitForSeconds(airTime);

        print("SwitchToGround");
        upgradeSpawner.StopCoroutine("SpawnVerticalUpgrade");
        obstacleSpawner.StopCoroutine("SpawnVerticalObstacle");
        yield return new WaitForSeconds(3);

        tableScene = true;
        backGroundScroll.yVelocity = 0;
        backGroundScroll.xVelocity = 4;
        verticalButton.SetActive(true);
        horizontalButtons.SetActive(false);
        rb.gravityScale = 3;
        rb.constraints = rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        upgradeSpawner.StartCoroutine("SpawnHorizontalUpgrade");
        obstacleSpawner.StartCoroutine("SpawnHorizontalObstacle");
    }
}