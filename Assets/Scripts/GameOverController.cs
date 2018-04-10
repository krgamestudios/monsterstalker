using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
	public Text scoreText;

	void Update() {
		if (Input.GetButtonDown ("Quit")) {
			Application.Quit ();
		}

		if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene ("gameplay");
		}
	
		//update the texts
		scoreText.text = "Score: " + PersistentData.score;
	}
}
