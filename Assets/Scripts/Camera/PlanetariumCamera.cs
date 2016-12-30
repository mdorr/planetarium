using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumCamera : MonoBehaviour {

	public Transform camTransform;

	public CelestialObject[] celestialObjects = new CelestialObject[0];

	public CelestialObject currentlyViewedObject = null;

	public float viewDistance = 15f;
	public float viewHeight = 10f;
	public float moveSpeed = 100f;
	public float rotateSpeed = 30f;

	// Use this for initialization
	void Start () {
		if (camTransform == null) {
			camTransform = Camera.main.transform;
		}
		currentlyViewedObject = celestialObjects [0];
	}

	void LateUpdate () {
		camTransform.position = Vector3.MoveTowards (camTransform.position, GetCameraPosition (), moveSpeed * Time.deltaTime);
		camTransform.rotation = Quaternion.RotateTowards (camTransform.rotation, GetCameraRotation (), rotateSpeed * Time.deltaTime);
	}

	void ChangeViewedObject (CelestialObject cObj) {
		if (cObj == null || currentlyViewedObject == cObj) {
			return;
		}

		currentlyViewedObject = null;
	}

	Vector3 GetCameraPosition () {
		if (currentlyViewedObject == null) {
			return Vector3.zero;
		}

		// From currently viewed object to origin
		Vector3 normal = -currentlyViewedObject.transform.position.normalized;

		return currentlyViewedObject.transform.position + (normal * viewDistance) + (Vector3.up * viewHeight);
	}

	Quaternion GetCameraRotation () {
		if (currentlyViewedObject == null) {
			return Quaternion.identity;
		}

		// From camera to currently viewed object
		Vector3 dir = (currentlyViewedObject.transform.position - camTransform.position).normalized;

		return Quaternion.LookRotation (dir, Vector3.up);
	}

	public void NextObject () {
		int curIndex = Array.IndexOf (celestialObjects, currentlyViewedObject);
		currentlyViewedObject = celestialObjects [(curIndex + 1) % celestialObjects.Length];
	}

	public void PreviousObject () {
		int curIndex = Array.IndexOf (celestialObjects, currentlyViewedObject);
		if (curIndex == 0) {
			currentlyViewedObject = celestialObjects [celestialObjects.Length - 1];
		} else {
			currentlyViewedObject = celestialObjects[curIndex - 1];
		}
	}


	void OnGUI() {
		if (GUILayout.Button ("<")) {
			PreviousObject ();
		}

		GUILayout.Label (currentlyViewedObject.objectName);

		if (GUILayout.Button (">")) {
			NextObject ();
		}

	}
}
