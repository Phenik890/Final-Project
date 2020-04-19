using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;

    private int zLength;
    public int factor;

    void Start()
    {
        zLength = 30;
    }

    void Update()
    {
        transform.position = new Vector3(0.0f, -10.0f, Mathf.Repeat(Time.time * scrollSpeed, zLength));
    }

    public void BGSpeedUp()
    {
        scrollSpeed = -5;
    }
}