using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public GameObject prefab; // The object to spawn when dropped
}
