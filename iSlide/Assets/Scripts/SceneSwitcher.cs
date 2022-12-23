using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private ObstacleSpawner obstacleSpawner;
    private UpgradeSpawner upgradeSpawner;
    [SerializeField] private GameObject backGround;
    private BackGroundScroll backGroundScroll;
    [SerializeField] private GameObject floor;
    private FloorMovement floorMovement;
    private int tableTime;
    private int airTime;
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
        upgradeSpawner = gameManager.GetComponent<UpgradeSpawner>();
        backGroundScroll = backGround.GetComponent<BackGroundScroll>();
        floorMovement = floor.GetComponent<FloorMovement>();
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        floorMovement.SpawnFloor();
        StartCoroutine("SwitchToAir");
    }

    IEnumerator SwitchToAir()
    {
        tableTime = Random.Range(10,20);
        yield return new WaitForSeconds(tableTime);

        obstacleSpawner.StopCoroutine("SpawnHorizontalObstacle");
        upgradeSpawner.StopCoroutine("SpawnHorizontalUpgrade");
        yield return new WaitForSeconds(3);

        tableScene = false;
        floorMovement.MoveFloorLeft();
        yield return new WaitForSeconds(1);

        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1);

        backGroundScroll.StartCoroutine("SwitchToGroundOffset");
        yield return new WaitForSeconds(0.5f);

        verticalButton.SetActive(false);
        horizontalButtons.SetActive(true);
        upgradeSpawner.StartCoroutine("SpawnVerticalUpgrade");
        obstacleSpawner.StartCoroutine("SpawnVerticalObstacle");
        StartCoroutine("SwitchToGround");
    }


    IEnumerator SwitchToGround()
    {
        airTime = Random.Range(10,20);
        yield return new WaitForSeconds(airTime);

        StopSpawningObjects();
        yield return new WaitForSeconds(3);

        tableScene = true;
        backGroundScroll.StartCoroutine("SwitchToAirOffset");
        verticalButton.SetActive(true);
        horizontalButtons.SetActive(false);
        rb.gravityScale = 3;
        rb.constraints = rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        StartSpawningObjects();
        floorMovement.SpawnFloor();
        StartCoroutine("SwitchToAir");
    }

    private void StopSpawningObjects()
    {
        upgradeSpawner.StopCoroutine("SpawnVerticalUpgrade");
        obstacleSpawner.StopCoroutine("SpawnVerticalObstacle");
    }

    private void StartSpawningObjects()
    {
        upgradeSpawner.StartCoroutine("SpawnHorizontalUpgrade");
        obstacleSpawner.StartCoroutine("SpawnHorizontalObstacle");
    }
}