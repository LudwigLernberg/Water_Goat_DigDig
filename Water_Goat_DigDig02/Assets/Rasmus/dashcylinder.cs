using UnityEngine;

public class DashWithVisual : MonoBehaviour
{
    [Header("Dash")]
    public float dashDistance = 10f;
    public float cooldown = 1f;

    [Header("Visual")]
    public GameObject cylinderPrefab;
    public float cylinderWidth = 0.2f;
    public float cylinderLifetime = 0.3f;

    float lastDashTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= lastDashTime + cooldown)
        {
            DoDash();
            lastDashTime = Time.time;
        }
    }

    void DoDash()
    {
        Vector3 start = transform.position;

        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 end = start + forward * dashDistance;

        // Move player
        transform.position = end;

        // Draw cylinder
        SpawnCylinder(start, end);
    }

    void SpawnCylinder(Vector3 start, Vector3 end)
    {
        if (cylinderPrefab == null)
        {
            Debug.LogError("NO CYLINDER PREFAB ASSIGNED");
            return;
        }

        Vector3 dir = end - start;
        float length = dir.magnitude;

        // Midpoint
        Vector3 pos = (start + end) / 2f;

        // Rotation (this is the key fix)
        Quaternion rot = Quaternion.LookRotation(dir);

        GameObject cyl = Instantiate(cylinderPrefab, pos, rot);

        // Rotate so cylinder (Y axis) aligns with forward (Z axis fix)
        cyl.transform.Rotate(90f, 0f, 0f);

        // Scale
        cyl.transform.localScale = new Vector3(cylinderWidth, length / 2f, cylinderWidth);

        Destroy(cyl, cylinderLifetime);
    }
}