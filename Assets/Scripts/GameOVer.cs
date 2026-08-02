using UnityEngine;

public class GameOver : MonoBehaviour
{
	public GameObject gameOverCanvas;

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

			gameOverCanvas.SetActive(true);

			// Stop gameplay
			Time.timeScale = 0f;
		}
	}
}