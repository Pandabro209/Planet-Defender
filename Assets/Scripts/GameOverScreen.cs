using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	public RectTransform arrow;

	public RectTransform tryAgainText;
	public RectTransform mainMenuText;

	int selected = 0;

	void Start()
	{
		UpdateArrow();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			selected++;

			if (selected > 1)
				selected = 0;

			UpdateArrow();
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			if (selected == 0)
			{
				TryAgain();
			}
			else
			{
				MainMenu();
			}
		}
	}

	void UpdateArrow()
	{
		if (selected == 0)
		{
			arrow.position = new Vector3(
				arrow.position.x,
				tryAgainText.position.y,
				arrow.position.z);
		}
		else
		{
			arrow.position = new Vector3(
				arrow.position.x,
				mainMenuText.position.y,
				arrow.position.z);
		}
	}

	void TryAgain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Planet defender unity 1");
	}

	void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main Menu"); // change this to your menu scene name
	}
}