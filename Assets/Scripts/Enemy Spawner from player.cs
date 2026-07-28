using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;

	public float spawnDistance = 20f;
	public float spawnRate = 2f;

	private float timer;

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= spawnRate)
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

		Vector3 spawnPosition = transform.position + direction * spawnDistance;

		GameObject enemy = Instantiate(
			enemyPrefab,
			spawnPosition,
			Quaternion.identity
		);

		enemy.GetComponent<Enemy>().SetTarget(transform);
	}
}