using Unity.VisualScripting;
using UnityEngine;

public class ChangeValue : MonoBehaviour
{
    public ValueHolder holder;

    private void Start()

    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            holder.value++;
            Debug.Log("+1");
        }
    }
}
