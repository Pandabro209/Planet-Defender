using UnityEngine;

public class SFXController : MonoBehaviour
{
	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		// Increase the volume to max capacity (clamped between 0.0f and 1.0f)
		audioSource.volume = 1.0f;
	}
}
