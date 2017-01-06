using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUi : MonoBehaviour {

	protected PlanetariumCamera cam;

	protected virtual void Start () {
		
		cam = GameObject.FindObjectOfType<PlanetariumCamera> () as PlanetariumCamera;

		if (cam == null) {
			Debug.LogError ("Cannot find required components. Please check objects in scene");
			gameObject.SetActive (false);
		}
	}
}
