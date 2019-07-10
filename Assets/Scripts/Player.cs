﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 25f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;


    void Start()
    {
        
    }


    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed;
        float xOffsetThisFrame = xOffset * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        transform.localPosition = new Vector3(clampedXPos,
                                              transform.localPosition.y, 
                                              transform.localPosition.z);

    }
}
