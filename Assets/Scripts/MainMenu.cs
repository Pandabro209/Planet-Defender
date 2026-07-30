using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        public void Play()
        {
            SceneManager.LoadScene("Planet defender")
        }
        public void Quit()
        {
            Application.Quit();
            Debug.Log("Player Has Quit The Game")
        }
    }
}
