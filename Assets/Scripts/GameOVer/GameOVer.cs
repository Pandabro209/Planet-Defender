using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
	public GameObject gameOverCanvas;

	public TMP_Text gameOverScoreText;
	public TMP_Text gameOverHighScoreText;
	public TMP_Text gameOverTotalPointsText;

	private bool gameOver = false;

	private void Start()
	{
		gameOverCanvas.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && !gameOver)
		{
			gameOver = true;

			// Save this run's score
			ScoreManager.Instance.EndRun();

			// Show all score information
			gameOverScoreText.text = "Score: " + ScoreManager.Instance.score;
			gameOverHighScoreText.text = "High Score: " + ScoreManager.Instance.highScore;
			gameOverTotalPointsText.text = "Total Points: " + ScoreManager.Instance.totalPoints;

			gameOverCanvas.SetActive(true);

			// Stop gameplay
			Time.timeScale = 0f;
		}
	}
}