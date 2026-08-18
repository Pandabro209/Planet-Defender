using UnityEngine;
using TMPro;

public class MainMenuScoreDisplay : MonoBehaviour
{
	public TMP_Text highScoreText;
	public TMP_Text totalPointsText;

	private void Start()
	{
		int highScore = PlayerPrefs.GetInt("HighScore", 0);
		int totalPoints = PlayerPrefs.GetInt("TotalPoints", 0);

		highScoreText.text = "High Score: " + highScore;
		totalPointsText.text = "Total Points: " + totalPoints;
	}
}