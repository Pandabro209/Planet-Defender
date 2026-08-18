using UnityEngine;

public class Shooter : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float fireRate = 0.5f;

	private float timer;

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= fireRate)
		{
			timer = 0f;

			GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

			Vector3 direction = (transform.position - transform.parent.position).normalized;

			bullet.GetComponent<Bullet>().SetDirection(direction);
		}
	}
}