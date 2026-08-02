using UnityEngine;
using UnityEngine.InputSystem;

public class SpinObject : MonoBehaviour
{
	[Header("Rotation Settings")]
	public float maxRotationSpeed = 180f;
	public float smoothing = 15f; // Higher = more responsive, Lower = smoother

	private float currentAngle = 0f;
	private float smoothedInput = 0f;

	void Update()
	{
		if (Keyboard.current == null)
			return;

		// Get input
		float input = 0f;

		if (Keyboard.current.aKey.isPressed)
			input = -1f;
		else if (Keyboard.current.dKey.isPressed)
			input = 1f;

		// Smooth the input
		smoothedInput = Mathf.Lerp(
			smoothedInput,
			input,
			smoothing * Time.deltaTime);

		// Update the rotation angle
		currentAngle += smoothedInput * maxRotationSpeed * Time.deltaTime;

		// Rotate around the Y axis
		transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);
	}
}