using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform target;

    [Header("Offset from the target")]
    public Vector3 offset = new Vector3(0, 5, -10);

    [Header("Smoothness")]
    public float followSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Set desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Make the camera look at the target
        transform.LookAt(target.position);
    }
}
