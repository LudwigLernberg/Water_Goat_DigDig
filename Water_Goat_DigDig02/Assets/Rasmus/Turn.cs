using UnityEngine;

public class RotateRelativeToCamera : MonoBehaviour
{
    public Transform cameraTransform;  // Assign your main camera here
    public float rotationSpeed = 10f;  // How fast the character rotates

    void Update()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Combine input into a direction vector
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);

        if (inputDirection.sqrMagnitude > 0.01f)
        {
            // Convert input direction relative to camera
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Flatten to horizontal plane
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = cameraForward * vertical + cameraRight * horizontal;

            // Rotate character to face moveDirection
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
