using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroler : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // The target (your third-person character)
    public float rotationSpeed = 5.0f;

    void Update()
    {
        // Rotate the camera around the character using arrow keys
        RotateCameraWithInput();
    }

    void RotateCameraWithInput()
    {
        // Get horizontal input (arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate rotation angle based on input
        float rotationAngle = horizontalInput * rotationSpeed;

        // Rotate the camera around the character
        transform.RotateAround(target.position, Vector3.up, rotationAngle);
    }
}
