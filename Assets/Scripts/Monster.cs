using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
	public int value;

	Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D> ();

		StartCoroutine (ReverseDirectionAfter (2f));
		StartCoroutine (DestroySelfAfter (4f));
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			GameObject.Find ("SoundController").GetComponent<SoundController> ().PlaySnapShot ();
			GameObject.Find ("Flash").GetComponent<Flash> ().StartFlash ();
			PersistentData.score += value;
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
		Destroy (gameObject);
	}
}
