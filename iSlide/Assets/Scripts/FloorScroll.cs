using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroll : MonoBehaviour
{
    Material material;
    [SerializeField] Vector2 offset;
    private int xVelocity = 9;


    void Awake()
    {
        material = this.GetComponent<Renderer>().material;
        SetFloorHorizontalOffset();
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;   
    }

    public void SetFloorHorizontalOffset()
    {
        offset = new Vector2(xVelocity, 0);
    }

    public void SetFloorOffsetNull()
    {
        offset = new Vector2(0, 0);   
    }
}