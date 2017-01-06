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
		this.gameObject.SetActive (true);
		StartCoroutine (SetDetailsText (cam.target.objectName));
	}

	private IEnumerator SetDetailsText(string celestialObject) {
		// This is required to force the ContentSizeFitter to trigger correctly - otherwise the text size is not calculated
		detailsText.enabled = false;
		detailsText.text = CelestialObject.getDetailText (celestialObject);
		yield return null;
		detailsText.enabled = true;
	}

	public override void Deactivate () {
		this.gameObject.SetActive (false);
		detailsText.text = "";
	}
}
