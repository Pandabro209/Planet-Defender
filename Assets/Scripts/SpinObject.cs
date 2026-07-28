using UnityEngine;

public class SpinObject : MonoBehaviour
{
	public float rotationSpeed = 100f;

	void Update()
	{
		// Press A or Left Arrow to spin left
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
		}

		// Press D or Right Arrow to spin right
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		}
	}
}
