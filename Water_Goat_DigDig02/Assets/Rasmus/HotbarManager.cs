using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public int size = 9;
    public Item[] items;
    public Image[] slotImages;
    public int selectedIndex = 0;
    public Image highlight;

    void Start()
    {
        items = new Item[size];
        UpdateUI();
    }

    void Update()
    {
        HandleInput();
        HandleScroll();
    }

    void HandleInput()
    {
        // Switch slots with number keys
        for (int i = 0; i < size; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                selectedIndex = i;
                UpdateUI();
            }
        }

        // Drop item
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
    }
    void HandleScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f) // scroll up
        {
            selectedIndex = (selectedIndex + 1) % size; // next slot
            UpdateUI();
        }
        else if (scroll < 0f) // scroll down
        {
            selectedIndex = (selectedIndex - 1 + size) % size; // previous slot
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] != null)
                slotImages[i].sprite = items[i].icon;
            else
                slotImages[i].sprite = null;

            // Highlight selected slot
            highlight.transform.position = slotImages[selectedIndex].transform.position;
        }
    }

    public void PickUpItem(Item item)
    {
        // Find first empty slot
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                UpdateUI();
                return;
            }
        }
        Debug.Log("Hotbar full!");
    }

    void DropItem()
    {
        if (items[selectedIndex] != null)
        {
            Instantiate(items[selectedIndex].prefab,
                        transform.position + transform.forward,
                        Quaternion.identity);
            items[selectedIndex] = null;
            UpdateUI();
        }
    }
}
