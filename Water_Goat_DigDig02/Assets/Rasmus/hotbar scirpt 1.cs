using UnityEngine;

public class HotbarStep1 : MonoBehaviour
{
    public string[] hotbar = new string[9]; // Simple hotbar storing item names
    private int selectedIndex = 0;          // Currently selected slot (0 = slot 1)

    void Start()
    {
        // Example items for testing
        hotbar[0] = "0";
        hotbar[1] = "1";
        hotbar[2] = "2";
    }

    void Update()
    {
        // Check keys 1-9
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                selectedIndex = i;
                Debug.Log("Selected slot " + (i + 1) + ": " + (hotbar[i] ?? "Empty"));
            }
        }
    }

    // Optional helper: get currently selected item
    public string GetSelectedItem()
    {
        return hotbar[selectedIndex];
    }
}
