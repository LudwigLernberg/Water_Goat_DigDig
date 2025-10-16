using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject Menu;

    public void ShowMainMenu()
    {
        Menu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}