using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnappyJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 7f;   // Adjust for jump height
    public LayerMask groundLayer;  // Layer for ground detection
    public float groundCheckDistance = 0.1f;

    private Rigidbody rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent tipping over
    }

    void Update()
    {
        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Reset vertical velocity for consistent jumps
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CheckGrounded()
    {
        // Raycast down to detect ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down,
                                     groundCheckDistance + 0.1f, groundLayer);
    }
}
