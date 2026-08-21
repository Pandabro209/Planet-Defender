using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
    public RectTransform arrow;

    public RectTransform fireRateText;
    public RectTransform buttonText;
    public RectTransform mainMenuText;
    public RectTransform startRunText;
    public RectTransform bulletSizeText;

    int selected = 0;

    void Start2()
    {
        UpdateArrow2();
    }

    void Update()
    {
        // Move selection
        if (Input.GetKeyDown(KeyCode.A))
        {
            selected++;

            if (selected > 2)
                selected = 0;

            UpdateArrow2();
        }

        // Confirm selection
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selected == 0)
            {
                // Play
                SceneManager.LoadScene("Planet defender unity 1");
            }
            else if (selected == 1)
            {
                // Upgrades
                SceneManager.LoadScene("Upgrades");
            }
        }
    }

    void UpdateArrow2()
    {
        if (selected == 0)
        {
            arrow.position = new Vector3(
                arrow.position.x,
                fireRateText.position.y,
                arrow.position.z);
        }
        else if (selected == 1)
        {
            arrow.position = new Vector3(
                arrow.position.x,
                bulletSizeText.position.y,
                arrow.position.z);
        }
        else if (selected == 2)
        {
            arrow.position = new Vector3(
                arrow.position.x,
                buttonText.position.y,
                arrow.position.z);
        }
        else if (selected == 3)
        {
            arrow.position = new Vector3(
                arrow.position.x,
                mainMenuText.position.y,
                arrow.position.z);
        }
        else
        {
            arrow.position = new Vector3(
                arrow.position.x,
                startRunText.position.y,
                arrow.position.z);
        }
    }
}
