using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;

	[Header("Sound Effects")]
	public AudioClip hitSound;

	private Vector3 direction;

	private int enemiesHit = 0;
	private int piercingLevel = 0;

	// Keeps track of enemies this bullet has already hit
	private HashSet<GameObject> hitEnemies = new HashSet<GameObject>();

	public void SetDirection(Vector3 newDirection)
	{
		direction = newDirection.normalized;
	}

	public void SetPiercingLevel(int level)
	{
		piercingLevel = level;
	}

	void Update()
	{
		transform.position += direction * speed * Time.deltaTime;

		Destroy(gameObject, 5f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Enemy"))
		{
			return;
		}

		// Don't hit the same enemy twice
		if (hitEnemies.Contains(other.gameObject))
		{
			return;
		}

		// Remember this enemy
		hitEnemies.Add(other.gameObject);

		// Play hit sound
		if (SFXManager.Instance != null)
		{
			SFXManager.Instance.PlaySFX(hitSound);
		}

		// Add score
		if (ScoreManager.Instance != null)
		{
			ScoreManager.Instance.AddScore(20);
		}

		// Destroy the enemy
		Destroy(other.gameObject);

		// Count the hit
		enemiesHit++;

		// Level 0 = 1 enemy
		// Level 1 = 2 enemies
		// Level 2 = 3 enemies
		int maxEnemiesHit = piercingLevel + 1;

		Debug.Log(
			"Bullet hit enemy " +
			enemiesHit +
			"/" +
			maxEnemiesHit
		);

		// Only destroy the bullet after reaching its limit
		if (enemiesHit >= maxEnemiesHit)
		{
			Destroy(gameObject);
		}
	}
}