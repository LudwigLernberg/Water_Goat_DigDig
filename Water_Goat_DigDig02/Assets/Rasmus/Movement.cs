using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnappyPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform orientation; // Usually your camera

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        // Get input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Calculate direction relative to orientation
        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * vertical + right * horizontal).normalized;

        // Apply velocity directly on XZ
        Vector3 newVelocity = moveDir * moveSpeed;
        newVelocity.y = rb.velocity.y; // keep existing vertical velocity (gravity, jump if any)
        rb.velocity = newVelocity;
    }
}
