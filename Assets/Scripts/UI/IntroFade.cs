using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroFade : MonoBehaviour {

	public Image bgImage = null;
	public Text bgText = null;

	public float bgFadeTime = 5f;
	public float textFadeTime = 1f;
	public float textFadeDelay = 4f;


	// Use this for initialization
	void Start () {
		StartCoroutine (fadeBgImage(bgFadeTime));
		StartCoroutine (fadeBgText (textFadeTime, textFadeDelay));
		Destroy (this.gameObject, Mathf.Max(bgFadeTime, (textFadeDelay + textFadeTime)) + 1);
	}


	IEnumerator fadeBgImage (float fadeTime) {
		float t = 0f;
		float s = 0f;
		float rate = 1f / Mathf.Max (fadeTime, 0.0001f);

		Color startColor = bgImage.color;
		Color endColor = startColor;
		endColor.a = 0.0f;

		while (t < 1f) {
			t += Time.deltaTime * rate;
			bgImage.color = Color.Lerp (startColor, endColor, t);
			yield return null;
		}
		yield return null;
	}

	IEnumerator fadeBgText (float fadeTime, float delay) {
		float t = 0f;
		float s = 0f;
		float rate = 1f / Mathf.Max (fadeTime, 0.0001f);

		Color startColor = bgText.color;
		Color endColor = startColor;
		endColor.a = 0.0f;

		yield return new WaitForSeconds (delay);

		while (t < 1f) {
			t += Time.deltaTime * rate;
			bgText.color = Color.Lerp (startColor, endColor, t);
			yield return null;
		}
		yield return null;
	}

}
