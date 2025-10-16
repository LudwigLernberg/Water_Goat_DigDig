/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public float JumpPower;
    public Rigidbody rb;

    float timeToNextJump = 0;


    private bool canJump = true;
    private bool isJumping;

    private float JumpingPower = 10f;
    private float JumpingTime = 0.2f;
    private float JumpingCooldown = 2f;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeToNextJump < Time.time)
        {
            Debug.Log("hjfghjk");
            rb.velocity = new Vector3(transform.localScale.x * JumpingPower, 10f);
            timeToNextJump = Time.time + JumpingCooldown;
        }
    }

   
}*/
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
        // Hoppa bara n�r vi �r p� marken
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAction();
        }
    }

    void JumpAction()
    {
        // Nollst�ll eventuell vertikal hastighet f�r konsekventa hopp
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // L�gg till hoppkraft
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionStay(Collision collision)
    {
        // Kolla om vi nuddar n�got p� marklagret
        if (((1 << collision.gameObject.layer) & groundMask) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Om vi inte l�ngre nuddar marken
        if (((1 << collision.gameObject.layer) & groundMask) != 0)
        {
            isGrounded = false;
        }
    }
}

