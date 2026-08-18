using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;

	public float spawnDistance = 20f;

	[Header("Spawn Rate")]
	public float startingSpawnRate = 2f;
	public float minimumSpawnRate = 0.5f;
	public float difficultySpeed = 0.02f;

	private float timer;
	private float elapsedTime;

	void Update()
	{
		elapsedTime += Time.deltaTime;
		timer += Time.deltaTime;

		float currentSpawnRate =
			minimumSpawnRate +
			(startingSpawnRate - minimumSpawnRate) *
			Mathf.Exp(-difficultySpeed * elapsedTime);

		if (timer >= currentSpawnRate)
		{
			timer = 0f;
			SpawnEnemy();
		}
	}

	void SpawnEnemy()
	{
		float angle = Random.Range(0f, 360f);

		Vector3 direction = new Vector3(
			Mathf.Cos(angle * Mathf.Deg2Rad),
			0,
			Mathf.Sin(angle * Mathf.Deg2Rad)
		);

		Vector3 spawnPosition =
			transform.position + direction * spawnDistance;

		GameObject enemy = Instantiate(
			enemyPrefab,
			spawnPosition,
			Quaternion.identity
		);

		enemy.GetComponent<Enemy>().SetTarget(transform);
	}
}