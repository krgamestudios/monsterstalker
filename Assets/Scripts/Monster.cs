using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
	public int value;

	void Awake() {
		StartCoroutine (DestroySelfAfter (30f));
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			//TODO: play death sound
			PersistentData.score += value;
			Destroy (gameObject);
		}
	}

	IEnumerator DestroySelfAfter(float seconds) {
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}
