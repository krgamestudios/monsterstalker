using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		StartFade (0.1f);
	}

	void StartFade(float period) {
		if (period <= 0) {
			throw new System.ArgumentOutOfRangeException("StartFade argument must be a positive floating point value");
		}
		StartCoroutine (FadeCoroutine (period));
	}

	IEnumerator FadeCoroutine(float period) {
		float absolute = 1.0f;
		float degree = -0.01f;
		const float lowerLimit = 0.8f;
		const float upperLimit = 1.0f;

		while(true) {
			//wait
			yield return new WaitForSeconds (period);

			//fade routine
			absolute += degree;

			//flip fade direction
			if (absolute <= lowerLimit || absolute >= upperLimit) {
				degree = -degree;
			}

			//fade
			spriteRenderer.color = new Color (absolute, absolute, absolute);
		}
	}
}
