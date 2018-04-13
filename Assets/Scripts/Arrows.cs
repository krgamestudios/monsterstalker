using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		StartCoroutine (FadeCoroutine (0.01f));
	}

	IEnumerator FadeCoroutine(float period) {
		float absolute = 1.0f;
		float degree = -0.01f;

		while(true) {
			//wait
			yield return new WaitForSeconds (period);

			//fade routine
			absolute += degree;

			//fade
			spriteRenderer.color = new Color (1, 1, 1, absolute);

			if (absolute == 0f) {
				Destroy (gameObject);
			}
		}
	}
}
