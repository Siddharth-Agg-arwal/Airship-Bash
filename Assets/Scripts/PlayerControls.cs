using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{

    // [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 3.5f;
    Vector3 currentPosition;
    // void OnEnable() {
    //     movement.Enable();    
    // }

    // void OnDisable() {
    //     movement.Disable();    
    // }
    void Start() {
    }
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation(){
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;

        // currentPosition = GetComponent<Transform>().position;
        float clampedXPos = Mathf.Clamp(rawXPos, rawXPos -xRange, rawXPos + xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, rawYPos -yRange, rawYPos + yRange);

        Debug.Log(clampedXPos);
        Debug.Log(clampedYPos);

        //LOOK INTO CLAMP IMPLEMENTATION IF IT IS EVEN POSSIBLE
        
        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z
        );
    }
}
