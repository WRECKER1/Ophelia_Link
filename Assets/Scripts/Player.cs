using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float speed = 25f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;
    [Tooltip("In m")] [SerializeField] float yRange = 6f;

    void Start()
    {
        
    }


    void Update()
    {
        processTranslation();
        processRotation();

    }

    private void processTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed;
        float xOffsetThisFrame = xOffset * Time.deltaTime;
        float yOffset = yThrow * speed;
        float yOffsetThisFrame = yOffset * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos,
                                              clampedYPos,
                                              transform.localPosition.z);
    }

    private void processRotation()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x,
                                                   transform.localRotation.y,
                                                   transform.localRotation.z);
    }
}
