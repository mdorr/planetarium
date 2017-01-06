using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGroup : MonoBehaviour {

	protected RectTransform rt;

	protected virtual void Awake () {
		rt = gameObject.GetComponent<RectTransform> () as RectTransform;
		if (rt == null) {
			Debug.Log ("Cannot find RectTransform! Does " + this.gameObject.name + " include one?");
			this.gameObject.SetActive (false);
			return;
		}
	}

	public virtual void Activate () {
		rt.localScale = Vector3.one;
	}

	public virtual void Deactivate () {
		rt.localScale = Vector3.zero;
	}

	public void ToggleActive (bool newStatus) {
		if (newStatus) {
			Activate ();
		} else {
			Deactivate ();
		}
	}
}
