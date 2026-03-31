using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        Hotbar hotbar = other.GetComponent<Hotbar>();

        if (hotbar != null)
        {
            hotbar.PickUpItem(item);
            Destroy(gameObject);
        }
    }
}