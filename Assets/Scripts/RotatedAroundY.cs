using UnityEngine;

public class RotatePickup : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
