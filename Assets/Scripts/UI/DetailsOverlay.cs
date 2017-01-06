using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsOverlay : UiGroup {

	public override void Activate () {
		this.gameObject.SetActive (true);
	}

	public override void Deactivate () {
		this.gameObject.SetActive (false);
	}
}
