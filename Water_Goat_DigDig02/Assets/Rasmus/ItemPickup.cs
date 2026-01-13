using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter(Collider other)
    {
        Hotbar hotbar = other.GetComponent<Hotbar>();
        if (hotbar != null)
        {
            hotbar.PickUpItem(item);
            Destroy(gameObject);
        }
    }
}
