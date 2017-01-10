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
		//rt.localScale = Vector3.one;
		StopAllCoroutines ();
		StartCoroutine (ToggleRotation (0f, 0.2f));
	}

	public virtual void Deactivate () {
		//rt.localScale = Vector3.zero;
		StopAllCoroutines ();
		StartCoroutine (ToggleRotation (90f, 0.2f));
	}

	IEnumerator ToggleRotation (float targetRotation, float rotateTime) {
		float t = 0f;
		float rate = 1f / Mathf.Max (rotateTime, 0.0001f);

		Vector3 startRotation = rt.eulerAngles;
		Vector3 endRotation = new Vector3 (targetRotation, startRotation.y, startRotation.z);

		while (t < 1f) {
			t += Time.deltaTime * rate;
			rt.eulerAngles = Vector3.Slerp (startRotation, endRotation, t);
			yield return null;
		}
		yield return null;
	}

	public void ToggleActive (bool newStatus) {
		if (newStatus) {
			Activate ();
		} else {
			Deactivate ();
		}
	}
}
