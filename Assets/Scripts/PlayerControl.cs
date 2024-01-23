using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Get horizontal and vertical inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction and apply velocity
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize(); // Ensure that diagonal movement is not faster
        movement = transform.TransformDirection(movement);
        movement *= movementSpeed;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Check for jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
