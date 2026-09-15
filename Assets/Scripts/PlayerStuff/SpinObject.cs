using UnityEngine;
using UnityEngine.InputSystem;

public class SpinObject : MonoBehaviour
{
	[Header("Turn Speeds")]
	public float slowTurnSpeed = 70f;
	public float fastTurnSpeed = 220f;

	[Header("Acceleration")]
	public float timeBeforeAccelerating = 0.2f;
	public float accelerationTime = 0.6f; // Increase this to make acceleration more gradual

	[Header("Smoothing")]
	public float speedSmoothTime = 0.04f;

	private float currentAngle;
	private float holdTime;

	private float currentTurnSpeed;
	private float turnSpeedVelocity;

	void Update()
	{
		if (Keyboard.current == null)
			return;

		float input = 0f;

		if (Keyboard.current.aKey.isPressed)
			input = -1f;
		else if (Keyboard.current.dKey.isPressed)
			input = 1f;

		// Track how long the key has been held.
		if (input != 0f)
			holdTime += Time.deltaTime;
		else
			holdTime = 0f;

		// Determine target speed.
		float targetSpeed = 0f;

		if (input != 0f)
		{
			targetSpeed = slowTurnSpeed;

			if (holdTime > timeBeforeAccelerating)
			{
				float t = Mathf.Clamp01(
					(holdTime - timeBeforeAccelerating) / accelerationTime);

				// Smooth acceleration curve
				t = Mathf.SmoothStep(0f, 1f, t);

				targetSpeed = Mathf.Lerp(slowTurnSpeed, fastTurnSpeed, t);
			}

			targetSpeed *= input;
		}

		// Smooth the actual turn speed
		currentTurnSpeed = Mathf.SmoothDamp(
			currentTurnSpeed,
			targetSpeed,
			ref turnSpeedVelocity,
			speedSmoothTime);

		currentAngle += currentTurnSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);
	}
}