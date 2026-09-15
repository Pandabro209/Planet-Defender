using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesToMainMenu : MonoBehaviour // Replace MainMenu with your actual script name
{
    public void LoadPlanetDefender()
    {
        Debug.Log("Button was clicked!"); // This line confirms the click event fires
        SceneManager.LoadScene("Main Menu");
    }
}