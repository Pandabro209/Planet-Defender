using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public RectTransform arrow;

	public RectTransform playText;
	public RectTransform upgradesText;
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

			if (selected > 2)
				selected = 0;

			UpdateArrow();

			// Main menu movement sound
			if (SFXManager.Instance != null)
			{
				SFXManager.Instance.PlaySFX(
					SFXManager.Instance.mainMenuMoveSound
				);
			}
		}

		// Confirm selection
		if (Input.GetKeyDown(KeyCode.D))
		{
			// Main menu selection sound
			if (SFXManager.Instance != null)
			{
				SFXManager.Instance.PlaySFX(
					SFXManager.Instance.mainMenuSelectSound
				);
			}

			if (selected == 0)
			{
				// Start a fresh run
				if (ScoreManager.Instance != null)
				{
					ScoreManager.Instance.StartNewRun();
				}

				// Play
				SceneManager.LoadScene("Planet defender unity 1");
			}
			else if (selected == 1)
			{
				// Upgrades
				SceneManager.LoadScene("Upgrades");
			}
			else if (selected == 2)
			{
				// Quit
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
		else if (selected == 1)
		{
			arrow.position = new Vector3(
				arrow.position.x,
				upgradesText.position.y,
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