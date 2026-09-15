using UnityEngine;
using TMPro;

public class GameScoreUI : MonoBehaviour
{
	public TMP_Text scoreText;

	private void Start()
	{
		if (ScoreManager.Instance != null)
		{
			ScoreManager.Instance.SetScoreText(scoreText);
		}
	}
}