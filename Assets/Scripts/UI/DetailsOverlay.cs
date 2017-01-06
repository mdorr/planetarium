using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsOverlay : UiGroup {

	public Text detailsText;
	private PlanetariumCamera cam;

	void Start () {
		cam = GameObject.FindObjectOfType<PlanetariumCamera> () as PlanetariumCamera;
	}

	public override void Activate () {
		detailsText.text = CelestialObject.getDetailText (cam.target.objectName);
		base.Activate ();
	}

	public override void Deactivate () {
		detailsText.text = "";
		base.Deactivate ();
	}
}
