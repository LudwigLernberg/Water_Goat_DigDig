using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    [Header("Camera Settings")]
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;
    public float distanceFromPlayer = 5f;
    public float heightOffset = 2f;

    private float mouseX;
    private float mouseY;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked; // optional, lock cursor
    }

    void Update()
    {
        HandleCamera();
        HandleMovement();
    }

    void HandleCamera()
    {
        // Mouse input
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -30f, 60f); // limit vertical rotation

        // Calculate camera position
        Vector3 offset = new Vector3(0, heightOffset, -distanceFromPlayer);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        cameraTransform.position = transform.position + rotation * offset;

        // Look at player
        cameraTransform.LookAt(transform.position + Vector3.up * heightOffset);
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    }
}
