using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navbar : UiGroup {

	public override void Activate () {
		this.gameObject.SetActive (true);
	}

	public override void Deactivate () {
		this.gameObject.SetActive (false);
	}
}
