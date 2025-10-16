using System.Collections;
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

   
}
