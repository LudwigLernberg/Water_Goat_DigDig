using UnityEngine;

public class DashForward : MonoBehaviour
{
    [Header("Dash Settings")]
    public float dashDistance = 10f;       // How far to dash
    public float cooldown = 1f;            // Cooldown in seconds

    private float lastDashTime = -Mathf.Infinity;

    void Update()
    {
        // Check for input and cooldown
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= lastDashTime + cooldown)
        {
            Dash();
            lastDashTime = Time.time;
        }
    }

    void Dash()
    {
        // Get forward direction of the player, zero out vertical component
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        // Move the player instantly
        transform.position += forward * dashDistance;
    }
}
