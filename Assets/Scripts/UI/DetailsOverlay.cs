using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsOverlay : UiGroup {

	public Text detailsText;

	public override void Activate () {
		this.gameObject.SetActive (true);
		StartCoroutine (SetDetailsText ("Mercury"));
	}

	private IEnumerator SetDetailsText(string celestialObject) {
		// This is required to force the ContentSizeFitter to trigger correctly - otherwise the text size is not calculated
		detailsText.enabled = false;
		detailsText.text = CelestialObject.getDetailText ("Mercury");
		yield return null;
		detailsText.enabled = true;

	}

	public override void Deactivate () {
		this.gameObject.SetActive (false);
		detailsText.text = "";
	}
}
