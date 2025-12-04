using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 10f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Hoppa bara när vi är på marken
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAction();
        }
    }

    void JumpAction()
    {
        // Nollställ eventuell vertikal hastighet för konsekventa hopp
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Lägg till hoppkraft
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionStay(Collision collision)
    {
        // Kolla om vi nuddar något på marklagret
        if (((1 << collision.gameObject.layer) & groundMask) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Om vi inte längre nuddar marken
        if (((1 << collision.gameObject.layer) & groundMask) != 0)
        {
            isGrounded = false;
        }
    }
}

