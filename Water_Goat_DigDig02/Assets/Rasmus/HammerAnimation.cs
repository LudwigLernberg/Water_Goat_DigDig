using UnityEngine;

public class AutoPingPongRotateX : MonoBehaviour
{
    public float rotationSpeed = 200f;

    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool goingForward = true;

    void Update()
    {
        // Starta rotation på klick
        if (Input.GetMouseButtonDown(0) && !isRotating)
        {
            StartRotation();
        }

        // Utför rotation
        if (isRotating)
        {
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // När rotationen är klar, byt riktning och rotera tillbaka
            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
            {
                transform.localRotation = targetRotation;

                // Om vi precis gick framåt, gör automatiskt tillbaka
                if (goingForward)
                {
                    goingForward = false;
                    targetRotation = transform.localRotation * Quaternion.Euler(-90f, 0f, 0f);
                }
                else
                {
                    // Stoppa rotationen efter tillbaka
                    isRotating = false;
                    goingForward = true; // redo för nästa klick
                }
            }
        }
    }

    void StartRotation()
    {
        targetRotation = transform.localRotation * Quaternion.Euler(90f, 0f, 0f);
        isRotating = true;
        goingForward = true;
    }
}
