using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject verticalButton;
    [SerializeField]
    private GameObject horizontalButtons;
    [SerializeField] 
    private GameObject floor;
    [SerializeField] 
    private GameObject backGround;
    private ObstacleSpawner obstacleSpawner;
    private UpgradeSpawner upgradeSpawner;
    private BackGroundScroll backGroundScroll;
    private FloorMovement floorMovement;
    private GameObject gameManager;
    private Rigidbody2D rb;
    private int tableTime;
    private int airTime;
    public bool tableScene;
    public GameObject player;


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

        StopSpawningHorizontalObjects();
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
		StartSpawningVerticalObjects();
        StartCoroutine("SwitchToGround");
    }

    IEnumerator SwitchToGround()
    {
        airTime = Random.Range(10,20);
        yield return new WaitForSeconds(airTime);

        StopSpawningVerticalObjects();
        yield return new WaitForSeconds(2);

        tableScene = true;
        backGroundScroll.StartCoroutine("SwitchToAirOffset");
        verticalButton.SetActive(true);
        horizontalButtons.SetActive(false);
        rb.gravityScale = 3;
        rb.constraints = rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        StartSpawningHorizontalObjects();
        floorMovement.SpawnFloor();
        yield return new WaitForSeconds(0.3f);

        player.transform.position = new Vector2(-6.5f, 0);
        //Spawn de player weer terug naar de default runner positie
        StartCoroutine("SwitchToAir");
    }

    private void StartSpawningVerticalObjects()
    {
		upgradeSpawner.StartCoroutine("SpawnVerticalUpgrade");
		obstacleSpawner.StartCoroutine("SpawnVerticalObstacle");
	}
    private void StopSpawningVerticalObjects()
    {
        upgradeSpawner.StopCoroutine("SpawnVerticalUpgrade");
        obstacleSpawner.StopCoroutine("SpawnVerticalObstacle");
    }

    private void StartSpawningHorizontalObjects()
    {
        upgradeSpawner.StartCoroutine("SpawnHorizontalUpgrade");
        obstacleSpawner.StartCoroutine("SpawnHorizontalObstacle");
    }

    private void StopSpawningHorizontalObjects()
    {
		obstacleSpawner.StopCoroutine("SpawnHorizontalObstacle");
		upgradeSpawner.StopCoroutine("SpawnHorizontalUpgrade");
	}
}