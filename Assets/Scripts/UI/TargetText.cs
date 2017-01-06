using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetText : TargetUi {

	protected Text txt;

	protected override void Start () {
		base.Start ();
		txt = gameObject.GetComponent<Text> () as Text;
	}

	void Update () {
		if (cam && cam.cameraMode == PlanetariumCamera.CAMERA_MODES.ORBIT && cam.target) {
			txt.text = cam.target.objectName;
		} else {
			txt.text = "";
		}
	}

}
