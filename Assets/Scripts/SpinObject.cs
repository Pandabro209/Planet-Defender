using UnityEngine;
using UnityEngine.InputSystem;

public class SpinObject : MonoBehaviour
{
	public float rotationSpeed = 100f;

	void Update()
	{
		if (Keyboard.current == null)
			return;

		if (Keyboard.current.aKey.isPressed)
		{
			transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
		}

		if (Keyboard.current.dKey.isPressed)
		{
			transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		}
	}
}