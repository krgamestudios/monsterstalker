using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			Destroy (gameObject);
		}
	}
}
