using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public RectTransform arrow;

    public RectTransform playText;
    public RectTransform quitText;

    int selected = 0;

    void Start()
    {
        UpdateArrow();
    }

    void Update()
    {
        // Move selection
        if (Input.GetKeyDown(KeyCode.A))
        {
            selected++;

            if (selected > 1)
                selected = 0;

            UpdateArrow();
        }

        // Confirm selection
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selected == 0)
            {
                SceneManager.LoadScene("Planet defender unity 1");
            }
            else
            {
                Application.Quit();
            }
        }
    }

    void UpdateArrow()
    {
        if (selected == 0)
        {
            arrow.position = new Vector3(
                arrow.position.x,
                playText.position.y,
                arrow.position.z);
        }
        else
        {
            arrow.position = new Vector3(
                arrow.position.x,
                quitText.position.y,
                arrow.position.z);
        }
    }
}
