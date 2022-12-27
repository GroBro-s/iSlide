using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
	Vector2 offset;
	private int offsetVelocity = 9;
	private GameObject newFloor;
	private FloorMovement newFloorMovement;
	public bool moveFloorUp;
	public bool moveFloorLeft;
	private int verticalMoveSpeed = 5;
	private int horizontalMoveSpeed = 11;
	private Vector2 floorSpawnPosition = new Vector2(0, -7);


	void Update()
	{
		if (transform.position.y > -5.25f && transform.position.x > -20)
		{
			moveFloorUp = false;
		}

		if(transform.position.y > 10)
		{
			Destroy(gameObject);
		}

		if (transform.position.x < -23)
		{
			moveFloorLeft = false;
		}

		this.GetComponent<Renderer>().material.mainTextureOffset += offset * Time.deltaTime;
	}

	void FixedUpdate()
	{
		if (moveFloorUp)
		{
			transform.Translate(Vector3.up * verticalMoveSpeed * Time.deltaTime);
		}

		if (moveFloorLeft)
		{
			transform.Translate(Vector3.left * horizontalMoveSpeed * Time.deltaTime);
		}
	}

	public void SpawnFloor()
	{
		newFloor = Instantiate(this.gameObject, floorSpawnPosition, Quaternion.identity);
		newFloorMovement = newFloor.GetComponent<FloorMovement>();
		newFloorMovement.moveFloorUp = true;
		SetFloorHorizontalOffset();
	}

	public void MoveFloorLeft()
	{
		newFloorMovement.moveFloorLeft = true;
		SetFloorOffsetNull();
	}

	public void MovefloorUp()
	{
		newFloorMovement.verticalMoveSpeed = 8;
		newFloorMovement.moveFloorUp = true;
	}

	private void SetFloorHorizontalOffset()
	{
		newFloorMovement.offset = new Vector2(offsetVelocity, 0);
	}

	private void SetFloorOffsetNull()
	{
		newFloorMovement.offset = new Vector2(0, 0);
	}
}