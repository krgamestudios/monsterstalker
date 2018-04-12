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

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D> ();
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
		Destroy (gameObject);
	}
}
