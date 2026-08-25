using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
    [Header("Arrow Indicator")]
    public RectTransform arrow;

    [Header("Menu Buttons (Assign in sequence)")]
    public RectTransform fireRateText;  // Index 0 (Top Left)
    public RectTransform bulletSizeText;// Index 1 (Top Center)
    public RectTransform buttonText;    // Index 2 (Top Right)
    public RectTransform mainMenuText;  // Index 3 (Bottom Left)
    public RectTransform startRunText;  // Index 4 (Bottom Right)

    [Header("Arrow Offset")]
    public float xOffset = -80f; // Distance to keep arrow to the LEFT of the target text

    private int selected = 0;
    private const int TOTAL_OPTIONS = 5;

    void Start()
    {
        if (arrow != null)
        {
            arrow.SetAsLastSibling(); // Keeps arrow rendering in front of all buttons
        }

        UpdateArrowPosition();
    }

    void Update()
    {
        // Cycle through options with 'A'
        if (Input.GetKeyDown(KeyCode.A))
        {
            selected = (selected + 1) % TOTAL_OPTIONS;
            UpdateArrowPosition();
        }

        // Confirm with 'D'
        if (Input.GetKeyDown(KeyCode.D))
        {
            ExecuteSelection();
        }
    }

    void UpdateArrowPosition()
    {
        RectTransform target = GetTargetRect();

        if (arrow != null && target != null)
        {
            // Move arrow to target's World Position, offset to the left of the button
            Vector3 targetWorldPos = target.position;
            arrow.position = new Vector3(targetWorldPos.x + xOffset, targetWorldPos.y, targetWorldPos.z);
        }
    }

    RectTransform GetTargetRect()
    {
        switch (selected)
        {
            case 0: return fireRateText;
            case 1: return bulletSizeText;
            case 2: return buttonText;
            case 3: return mainMenuText;
            case 4: return startRunText;
            default: return fireRateText;
        }
    }

    void ExecuteSelection()
    {
        switch (selected)
        {
            case 0:
                Debug.Log("Fire Rate Selected");
                break;
            case 1:
                Debug.Log("Bullet Size Selected");
                break;
            case 2:
                Debug.Log("Button Selected");
                break;
            case 3:
                SceneManager.LoadScene("Main Menu");
                break;
            case 4:
                SceneManager.LoadScene("Planet defender unity 1");
                break;
        }
    }
}