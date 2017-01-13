using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour {

	public int superSize = 4;

	private int number = 0;

	void Update () {
		if (Input.GetKeyDown ("space")) {
			TakeScreenshot ();
		}
	}

	void TakeScreenshot() {
		string path = Application.persistentDataPath + "/screenshot_" + number.ToString () + ".png";
		Debug.Log ("Storing screenshot at " + path);
		Application.CaptureScreenshot(path, superSize);
		number++;
	}
}
