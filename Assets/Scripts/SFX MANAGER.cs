using UnityEngine;

public class SFXManager : MonoBehaviour
{
	public static SFXManager Instance;

	private AudioSource audioSource;

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

	public void PlaySFX(AudioClip clip)
	{
		if (clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}