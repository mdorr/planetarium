using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : TargetUi {

	protected Button btn;

	protected override void Start () {
		base.Start ();
		btn = gameObject.GetComponent<Button> () as Button;
	}

	void Update () {
		if (cam.cameraMode != PlanetariumCamera.CAMERA_MODES.ORBIT) {
			btn.interactable = false;
		} else {
			btn.interactable = true;
		}
	}
}



