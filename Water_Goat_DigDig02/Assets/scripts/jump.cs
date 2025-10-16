using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public float JumpPower;
    public Rigidbody rb;
    private bool onFloor = true;

    private bool canJump = true;
    private bool isJumping;

    private float JumpingPower = 10f;
    private float JumpingTime = 0.2f;
    private float JumpingCooldown = 10f;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& onFloor == true)
        {
            rb.velocity = Vector3.up * JumpingPower;
        }
    }

    private IEnumerator Jump()
    {
        canJump = false;
        isJumping = true;
        rb.velocity = new Vector3(transform.localScale.x * JumpingPower, 0f);
        yield return new WaitForSeconds(JumpingTime);
        isJumping = false;
        yield return new WaitForSeconds(JumpingCooldown);
        canJump = true;
    }
}
