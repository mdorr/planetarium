using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skysphere: Ensure the Skysphere follows the camera
/// </summary>
public class Skysphere : MonoBehaviour {

	public Transform skysphere;
	public Transform camera;

	void LateUpdate () {
		if (skysphere != null && camera != null) {
			skysphere.position = camera.position;
		}
	}
}
