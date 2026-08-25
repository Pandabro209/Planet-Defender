using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance;

	[Header("Current Run")]
	public int score = 0;

	[Header("High Score")]
	public int highScore = 0;

	[Header("Total Points")]
	public int totalPoints = 0;

	[Header("UI")]
	public TMP_Text scoreText;

	private void Awake()
	{
		// Make sure there is only one ScoreManager
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);

			// Load saved values
			highScore = PlayerPrefs.GetInt("HighScore", 0);
			totalPoints = PlayerPrefs.GetInt("TotalPoints", 0);

			// Start with a fresh run
			score = 0;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		UpdateScoreUI();
	}

	public void StartNewRun()
	{
		score = 0;
		UpdateScoreUI();
	}

	public void AddScore(int amount)
	{
		score += amount;

		// Update high score if necessary
		if (score > highScore)
		{
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}

		UpdateScoreUI();
	}

	public void EndRun()
	{
		// Add this run's score to the permanent total
		totalPoints += score;

		PlayerPrefs.SetInt("TotalPoints", totalPoints);
		PlayerPrefs.SetInt("HighScore", highScore);

		PlayerPrefs.Save();
	}

	private void UpdateScoreUI()
	{
		if (scoreText != null)
		{
			scoreText.text = "Score: " + score;
		}
	}

	public void SetScoreText(TMP_Text newScoreText)
	{
		scoreText = newScoreText;
		UpdateScoreUI();
	}
}