using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UiGroup : MonoBehaviour {

	public abstract void Activate ();
	public abstract void Deactivate ();

	public void ToggleActive (bool newStatus) {
		if (newStatus) {
			Activate ();
		} else {
			Deactivate ();
		}
	}
}
