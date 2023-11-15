using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    // [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xRange = 25f;
    [SerializeField] float yRange = 3.5f;
    // Start is called before the first frame update

    // void OnEnable() {
    //     movement.Enable();    
    // }

    // void OnDisable() {
    //     movement.Disable();
    // }
    
    // Update is called once per frame
    void Update()
    {

        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        
        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z
        );
    }
}
