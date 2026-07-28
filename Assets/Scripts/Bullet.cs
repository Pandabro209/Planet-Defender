using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;

	private Vector3 direction;

	public void SetDirection(Vector3 newDirection)
	{
		direction = newDirection.normalized;
	}

	void Update()
	{
		transform.position += direction * speed * Time.deltaTime;

		Destroy(gameObject, 5f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject); // destroy enemy
			Destroy(gameObject);       // destroy bullet
		}
	}
}