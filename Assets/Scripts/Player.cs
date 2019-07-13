using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float speed = 25f;
    [Tooltip("In m")] [SerializeField] float xRange = 12f;
    [Tooltip("In m")] [SerializeField] float yRange = 10f;


    [SerializeField] float positionPitchFactor = -1.5f;
    [SerializeField] float positionYawFactor = 1.9f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow;
    float yThrow;

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
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

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
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,
                                                   yaw,
                                                   roll);
    }
}
