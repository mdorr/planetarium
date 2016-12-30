using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {

	public Transform target;
	public float distance = 5.0f;
	public float xSpeed = 30.0f;
	public float ySpeed = 30.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float distanceMin = .5f;
	public float distanceMax = 15f;

	private Rigidbody rigidbody;

	float x = 0.0f;
	float y = 0.0f;

	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	void LateUpdate () {
		Vector2 touchDelta = Vector2.zero;

		#if UNITY_IOS
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			touchDelta = Input.GetTouch (0).deltaPosition;
		}
		#else
		if (Input.GetMouseButton (0)) {
			touchDelta.x = Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
			touchDelta.y = Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
		} 
		#endif

		if (target) {
			x += touchDelta.x * xSpeed * distance * Time.deltaTime;
			y -= touchDelta.y * ySpeed * Time.deltaTime;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}