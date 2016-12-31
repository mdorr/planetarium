using UnityEngine;
using System.Collections;
using System;

public class OrbitCamera : MonoBehaviour {

	public enum CAMERA_MODES {
		INIT = 0,
		ORBIT = 1,
		MOVE = 2
	}

	public CAMERA_MODES cameraMode = CAMERA_MODES.INIT;

	public CelestialObject[] celestialObjects = new CelestialObject[0];
	public CelestialObject target;

	public float distance = 5.0f;
	public float xSpeed = 30.0f;
	public float ySpeed = 30.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float moveTime = 2f;

	float x = 0.0f;
	float y = 0.0f;

	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	void InitCamera () {
		ChangeCameraTarget (celestialObjects [0]);
	}

	void LateUpdate () {
		switch (cameraMode) {
		case CAMERA_MODES.INIT:
			InitCamera ();
			break;
		case CAMERA_MODES.ORBIT:
			OrbitCam ();
			break;
		}
	}

	void OrbitCam () {
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

			//Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 negDistance = -Vector3.forward * distance;
			Vector3 position = rotation * negDistance + target.transform.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	IEnumerator MoveCamera (CelestialObject cObj, float time) {
		cameraMode = CAMERA_MODES.MOVE;
		float t = 0f;
		float s = 0f;
		float rate = 1f / Mathf.Max (time, 0.0001f);

		Vector3 initialPosition = transform.position;
		Quaternion initialRotation = transform.rotation;

		Vector3 targetPosition;
		Quaternion targetRotation = Quaternion.Euler (20f, 0f, 0f);
		Vector3 negDistance = -Vector3.forward * distance;

		while (t < 1f) {
			t += Time.deltaTime * rate;
			s = Mathf.SmoothStep (0f, 1f, t);
			targetPosition = targetRotation * negDistance + cObj.transform.position;

			transform.position = Vector3.Lerp (initialPosition, targetPosition, s);
			transform.rotation = Quaternion.Slerp (initialRotation, targetRotation, s);

			yield return null;
		}
		target = cObj;

		// Update angles for orbit cam
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		cameraMode = CAMERA_MODES.ORBIT;
		yield return null;
	}

	void ChangeCameraTarget (CelestialObject cObj) {
		if (cameraMode == CAMERA_MODES.MOVE) {
			return;
		}
		StartCoroutine (MoveCamera (cObj, moveTime));
	}

	public void NextObject () {
		int curIndex = Array.IndexOf (celestialObjects, target);
		ChangeCameraTarget (celestialObjects [(curIndex + 1) % celestialObjects.Length]);
	}

	public void PreviousObject () {
		int curIndex = Array.IndexOf (celestialObjects, target);
		if (curIndex == 0) {
			ChangeCameraTarget (celestialObjects [celestialObjects.Length - 1]);
		} else {
			ChangeCameraTarget (celestialObjects [curIndex - 1]);
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