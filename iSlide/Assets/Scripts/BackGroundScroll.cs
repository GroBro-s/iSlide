using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    Material material;
    [SerializeField] Vector2 offset;
    private int xVelocity = 4;
    private int yVelocity = -4;


    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        SetHorizontalOffset();
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;   
    }

    void SetHorizontalOffset()
    {
        offset = new Vector2(xVelocity, 0);
    }

    void SetVerticalOffset()
    {
        offset = new Vector2(0, yVelocity);
    }

    void SetOffsetNull()
    {
        offset = new Vector2(0, 0);
    }

    public void SwitchToAirOffset()
    {
        SetOffsetNull();
        SetVerticalOffset();
    }

    public void SwitchToGroundOffset()
    {
        SetVerticalOffset();
        SetHorizontalOffset();
    }
}
