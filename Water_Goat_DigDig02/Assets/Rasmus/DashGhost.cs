using UnityEngine;
using System.Collections;

public class TemporaryObjectActivator : MonoBehaviour
{
    [Header("Settings")]
    public GameObject objectToActivate; // The object you want to show
    public float duration = 0.5f;       // How long it stays active

    /// <summary>
    /// Call this function to show the object temporarily
    /// </summary>
    public void ActivateTemporarily(Vector3 position)
    {
        if (objectToActivate != null)
        {
            objectToActivate.transform.position = position; // optional, set position
            StartCoroutine(ShowObject());
        }
    }

    private IEnumerator ShowObject()
    {
        objectToActivate.SetActive(true);
        yield return new WaitForSeconds(duration);
        objectToActivate.SetActive(false);
    }
}
