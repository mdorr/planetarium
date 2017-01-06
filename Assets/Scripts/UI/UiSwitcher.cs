using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSwitcher : MonoBehaviour {

	public UiGroup navBar;
	public UiGroup detailsOverlay;

	// Use this for initialization
	void Start () {
		if (!navBar || !detailsOverlay) {
			Debug.Log ("Not all required references are set! Check UiSwitcher component on " + this.gameObject.name);
			this.gameObject.SetActive (false);
			return;
		}
		navBar.ToggleActive (true);
		detailsOverlay.ToggleActive (false);

	}
	
	public void ToggleDetails (bool newState) {
		navBar.ToggleActive (!newState);
		detailsOverlay.ToggleActive (newState);
	}
}
