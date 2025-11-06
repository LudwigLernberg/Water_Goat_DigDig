using UnityEngine;

public class PlayerRotateWithCamera : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Transform cameraTransform; // Assign your main camera

    void Update()
    {
        // Get raw input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v);

        if (input.magnitude >= 0.1f)
        {
            // Camera-relative directions
            Vector3 camForward = cameraTransform.forward;
            camForward.y = 0;
            camForward.Normalize();

            Vector3 camRight = cameraTransform.right;
            camRight.y = 0;
            camRight.Normalize();

            // Convert input to world direction relative to camera
            Vector3 moveDir = camForward * v + camRight * h;

            // Rotate player to face moveDir
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(moveDir),
                                                  rotationSpeed * Time.deltaTime);
        }
    }
}
