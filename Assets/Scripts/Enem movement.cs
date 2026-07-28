using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 3f;

	private Transform player;

	public void SetTarget(Transform target)
	{
		player = target;
	}

	void Update()
	{
		if (player == null)
			return;

		Vector3 direction = (player.position - transform.position).normalized;

		transform.position += direction * speed * Time.deltaTime;
	}
}