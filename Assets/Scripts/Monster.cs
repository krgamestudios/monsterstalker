using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
	public int value;
	public float lifespan {
		set {
			//hackfix
			StartCoroutine (ReverseDirectionAfter (value / 2));
			StartCoroutine (DestroySelfAfter (value));
		}
	}

	Rigidbody2D rigidBody;
	SpriteRenderer spriteRenderer;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			GameObject.Find ("SoundController").GetComponent<SoundController> ().PlaySnapShot ();
			GameObject.Find ("Flash").GetComponent<Flash> ().StartFlash ();
			PersistentData.score += value;
			PersistentData.monsterNames.Add (gameObject.name);
			Destroy (gameObject);
		}
	}

	IEnumerator ReverseDirectionAfter(float seconds) {
		yield return new WaitForSeconds (seconds);
		rigidBody.velocity = new Vector2 (-rigidBody.velocity.x, -rigidBody.velocity.y);
	}

	IEnumerator DestroySelfAfter(float seconds) {
		//clean up lost objects
		yield return new WaitForSeconds (seconds);
		StartCoroutine (FadeCoroutine(0.01f));
	}

	IEnumerator FadeCoroutine(float period) {
		float absolute = 1.0f;
		float degree = -0.02f;

		while(true) {
			//wait
			yield return new WaitForSeconds (period);

			//fade routine
			absolute += degree;

			//fade
			spriteRenderer.color = new Color (1, 1, 1, absolute);

			if (absolute <= 0f) {
				Destroy (gameObject);
			}
		}
	}
}
