
using UnityEngine;

public class SFXManager : MonoBehaviour
{
	public static SFXManager Instance;

	private AudioSource audioSource;


	// =========================================
	// UPGRADE MENU SFX
	// =========================================

	[Header("Upgrade Menu SFX")]
	public AudioClip upgradeMenuMoveSound;
	public AudioClip upgradeMenuSelectSound;


	// =========================================
	// MAIN MENU SFX
	// =========================================

	[Header("Main Menu SFX")]
	public AudioClip mainMenuMoveSound;
	public AudioClip mainMenuSelectSound;


	// =========================================
	// UPGRADE SFX
	// =========================================

	[Header("Upgrade SFX")]
	public AudioClip upgradeBuySound;
	public AudioClip upgradeFailSound;


	// =========================================
	// GAMEPLAY SFX
	// =========================================

	[Header("Gameplay SFX")]
	public AudioClip shootSound;
	public AudioClip enemyHitSound;
	public AudioClip playerDeathSound;


	// =========================================
	// PITCH VARIATION
	// =========================================

	[Header("Shoot Pitch Variation")]
	[Range(0.9f, 1f)]
	public float shootMinimumPitch = 0.98f;

	[Range(1f, 1.1f)]
	public float shootMaximumPitch = 1.02f;


	[Header("Enemy Hit Pitch Variation")]
	[Range(0.5f, 1f)]
	public float enemyHitMinimumPitch = 0.90f;

	[Range(1f, 2f)]
	public float enemyHitMaximumPitch = 1.10f;


	// =========================================
	// AWAKE
	// =========================================

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;

			DontDestroyOnLoad(gameObject);

			audioSource = GetComponent<AudioSource>();
		}
		else
		{
			Destroy(gameObject);
		}
	}


	// =========================================
	// PLAY SFX
	// =========================================

	public void PlaySFX(AudioClip clip)
	{
		if (clip == null)
		{
			return;
		}

		// Shoot sound gets subtle variation
		if (clip == shootSound)
		{
			audioSource.pitch = Random.Range(
				shootMinimumPitch,
				shootMaximumPitch
			);
		}
		// Enemy hit gets stronger variation
		else if (clip == enemyHitSound)
		{
			audioSource.pitch = Random.Range(
				enemyHitMinimumPitch,
				enemyHitMaximumPitch
			);
		}
		// Everything else stays at normal pitch
		else
		{
			audioSource.pitch = 1f;
		}

		audioSource.PlayOneShot(clip);
	}
}