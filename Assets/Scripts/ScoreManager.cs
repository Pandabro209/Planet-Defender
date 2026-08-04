using UnityEngine;
using TMPro;    // Only if you're using TextMeshPro

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance;

	public int score = 0;

	public TMP_Text scoreText;

	private void Awake()
	{
		Instance = this;
	}

	public void AddScore(int amount)
	{
		score += amount;

		if (scoreText != null)
			scoreText.text = "Score: " + score;
	}
}