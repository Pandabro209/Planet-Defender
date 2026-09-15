
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public GameObject bulletPrefab;

	[Header("Base Fire Rate")]
	public float fireRate = 0.5f;

	[Header("Upgrade")]
	public float fireRateUpgradeMultiplier = 0.9f;

	private float timer;


	void Update()
	{
		timer += Time.deltaTime;

		float currentFireRate = fireRate;

		// Get Fire Rate upgrade from saved data
		int fireRateLevel =
			PlayerPrefs.GetInt("FireRateLevel", 0);

		currentFireRate = fireRate * Mathf.Pow(
			fireRateUpgradeMultiplier,
			fireRateLevel
		);


		if (timer >= currentFireRate)
		{
			timer = 0f;

			GameObject bullet = Instantiate(
				bulletPrefab,
				transform.position,
				Quaternion.identity
			);

			// Play firing sound through SFX Manager
			if (SFXManager.Instance != null)
			{
				SFXManager.Instance.PlaySFX(
					SFXManager.Instance.shootSound
				);
			}

			Vector3 direction = (
				transform.position -
				transform.parent.position
			).normalized;

			Bullet bulletScript =
				bullet.GetComponent<Bullet>();

			bulletScript.SetDirection(direction);


			// Get Piercing upgrade from saved data
			int piercingLevel =
				PlayerPrefs.GetInt("PiercingLevel", 0);

			bulletScript.SetPiercingLevel(
				piercingLevel
			);
		}
	}
}
