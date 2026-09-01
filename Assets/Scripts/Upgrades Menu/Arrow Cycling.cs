using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
	[Header("Arrow Indicator")]
	public RectTransform arrow;

	[Header("Menu Buttons (Assign in sequence)")]
	public RectTransform fireRateText;
	public RectTransform piercingText;
	public RectTransform jumpstartText;
	public RectTransform mainMenuText;
	public RectTransform startRunText;

	[Header("Arrow Offset")]
	public float xOffset = -80f;

	private int selected = 0;
	private const int TOTAL_OPTIONS = 5;


	void Start()
	{
		if (arrow != null)
		{
			arrow.SetAsLastSibling();
		}

		UpdateArrowPosition();
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			selected = (selected + 1) % TOTAL_OPTIONS;
			UpdateArrowPosition();
		}

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
			Vector3 targetWorldPos = target.position;

			arrow.position = new Vector3(
				targetWorldPos.x + xOffset,
				targetWorldPos.y,
				targetWorldPos.z
			);
		}
	}


	RectTransform GetTargetRect()
	{
		switch (selected)
		{
			case 0: return fireRateText;
			case 1: return piercingText;
			case 2: return jumpstartText;
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
				// Fire Rate
				UpgradeManager.Instance.BuyFireRateUpgrade();
				break;

			case 1:
				// Piercing
				UpgradeManager.Instance.BuyPiercingUpgrade();
				break;

			case 2:
				// Jumpstart
				UpgradeManager.Instance.BuyJumpstartUpgrade();
				break;

			case 3:
				// Main Menu
				SceneManager.LoadScene("Main Menu");
				break;

			case 4:
				// Start Run
				if (ScoreManager.Instance != null)
				{
					ScoreManager.Instance.StartNewRun();
				}

				SceneManager.LoadScene("Planet defender unity 1");
				break;
		}
	}
}