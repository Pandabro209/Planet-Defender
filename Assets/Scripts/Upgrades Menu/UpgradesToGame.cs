using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesToGame : MonoBehaviour 
{
    public void LoadPlanetDefender()
    {
        Debug.Log("Button was clicked!");
        SceneManager.LoadScene("Planet defender unity 1");
    }
}