using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour {

	[Tooltip("Name of the celestial object")]
	public string objectName = "";

	public static string getDetailText (string name) {
		TextAsset txt = Resources.Load("Text/" + name.ToLower ()) as TextAsset;
		return txt ? txt.text : "";
	}
}
