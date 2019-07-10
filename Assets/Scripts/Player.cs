﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;


    void Start()
    {
        
    }


    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed;
        float xOffsetThisFrame = xOffset * Time.deltaTime;
        print(xOffsetThisFrame);

    }
}
