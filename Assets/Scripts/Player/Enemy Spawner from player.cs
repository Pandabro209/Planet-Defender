using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;

	public float spawnDistance = 20f;

	[Header("Spawn Rate")]
	public float startingSpawnRate = 2f;
	public float minimumSpawnRate = 0.2f;
	public float difficultySpeed = 0.02f;

	[Header("Jumpstart")]
	public float secondsPerIntensityLevel = 10f;

	[Header("Enemy Scaling")]
	public float enemiesPerSpawnIncreaseTime = 60f;
	public int startingEnemiesPerSpawn = 1;

	[Header("Spawn Rate Catch-Up")]
	public float initialSetback = 20f;

	[Tooltip("0.9 = keep 90% of the previous setback each time")]
	[Range(0f, 1f)]
	public float setbackReductionMultiplier = 0.9f;

	private float timer;
	private float elapsedTime;

	private int enemiesPerSpawn;
	private int lastEnemyCount;

	private float spawnRateTimeOffset;


	void Start()
	{
		// Load Jumpstart level
		int jumpstartLevel =
			PlayerPrefs.GetInt("JumpstartLevel", 0);

		// Start further along the difficulty curve
		elapsedTime =
			jumpstartLevel * secondsPerIntensityLevel;

		// Work out how many enemies we should start with
		enemiesPerSpawn =
			startingEnemiesPerSpawn +
			Mathf.FloorToInt(
				elapsedTime / enemiesPerSpawnIncreaseTime
			);

		lastEnemyCount = enemiesPerSpawn;

		Debug.Log(
			"Jumpstart Level: " +
			jumpstartLevel +
			" | Starting Time: " +
			elapsedTime +
			" | Enemies Per Spawn: " +
			enemiesPerSpawn
		);
	}


	void Update()
	{
		elapsedTime += Time.deltaTime;
		timer += Time.deltaTime;

		// Work out how many enemies should currently spawn
		int targetEnemyCount =
			startingEnemiesPerSpawn +
			Mathf.FloorToInt(
				elapsedTime / enemiesPerSpawnIncreaseTime
			);

		// Check if we have reached a new enemy-count stage
		if (targetEnemyCount > lastEnemyCount)
		{
			int increases =
				targetEnemyCount - lastEnemyCount;

			for (int i = 0; i < increases; i++)
			{
				IncreaseEnemyCount();
			}

			lastEnemyCount = targetEnemyCount;
		}

		// Calculate the effective time used by the spawn-rate curve
		float effectiveDifficultyTime =
			elapsedTime - spawnRateTimeOffset;

		effectiveDifficultyTime =
			Mathf.Max(0f, effectiveDifficultyTime);

		// Existing exponential difficulty curve
		float currentSpawnRate =
			minimumSpawnRate +
			(startingSpawnRate - minimumSpawnRate) *
			Mathf.Exp(
				-difficultySpeed * effectiveDifficultyTime
			);

		if (timer >= currentSpawnRate)
		{
			timer = 0f;
			SpawnEnemies();
		}
	}


	private void IncreaseEnemyCount()
	{
		enemiesPerSpawn++;

		// Calculate the setback for this increase.
		// Each new increase gets a percentage of the previous setback.
		float setback =
			initialSetback *
			Mathf.Pow(
				setbackReductionMultiplier,
				enemiesPerSpawn - 2
			);

		spawnRateTimeOffset += setback;

		Debug.Log(
			"Enemy count increased to " +
			enemiesPerSpawn +
			" per spawn! Spawn rate setback: " +
			setback +
			" seconds."
		);
	}


	private void SpawnEnemies()
	{
		for (int i = 0; i < enemiesPerSpawn; i++)
		{
			SpawnEnemy();
		}
	}


	private void SpawnEnemy()
	{
		float angle =
			Random.Range(0f, 360f);

		Vector3 direction =
			new Vector3(
				Mathf.Cos(angle * Mathf.Deg2Rad),
				0,
				Mathf.Sin(angle * Mathf.Deg2Rad)
			);

		Vector3 spawnPosition =
			transform.position +
			direction * spawnDistance;

		GameObject enemy =
			Instantiate(
				enemyPrefab,
				spawnPosition,
				Quaternion.identity
			);

		enemy.GetComponent<Enemy>()
			.SetTarget(transform);
	}
}