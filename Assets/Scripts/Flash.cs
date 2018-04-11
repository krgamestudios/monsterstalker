using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	float alpha = 1.0f;
	const float gradient = 0.1f;
	const float period = 0.1f;

	float lastClick; //prevent double exposure

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		spriteRenderer.color = new Color (1f, 1f, 1f, 0f);
	}

	public void StartFlash() {
		StartCoroutine (FlashCoroutine ());
	}

	IEnumerator FlashCoroutine() {
		lastClick = Time.time;
		float thisClick = lastClick;

		alpha = 1.0f;

		while (alpha > 0) {
			yield return new WaitForSeconds (period);

			if (thisClick != lastClick) {
				break;
			}

			alpha -= gradient;
			spriteRenderer.color = new Color (1f, 1f, 1f, alpha);
		}
	}
}
