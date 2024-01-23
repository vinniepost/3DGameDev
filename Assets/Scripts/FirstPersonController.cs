using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 8f;

    private Camera playerCamera;
    private float verticalLookRotation = 0f;
    private bool isGrounded;

    private bool isPaused = false;
    public GameObject pauseScreen;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = GetComponentInChildren<Camera>();
        if (pauseScreen == null)
        {
            Debug.LogError("Pause Screen not assigned properly!");
        }
        else
        {
            // Disable the pause screen at the start
            pauseScreen.SetActive(false);
        }
    }

    void Update()
    {
        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Sprinting
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        float speed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * verticalInput + right * horizontalInput;
        Vector3 velocity = movement.normalized * speed;

        transform.Translate(velocity * Time.deltaTime, Space.World);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Player Look (Mouse)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);
        isGrounded = false;
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);

        


        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
