using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public Text timerText;
	public Text scoreText;

	void Awake() {
		PersistentData.timer = 60;
		PersistentData.score = 0;

		StartCoroutine (DecreaseTick ());
	}

	void Update() {
		if (Input.GetButtonDown ("Quit")) {
			Application.Quit ();
		}

		if (PersistentData.timer <= 0) {
			SceneManager.LoadScene ("gameover");
		}

		//track this
		if (Input.GetMouseButtonDown(0)) {
			PersistentData.clicks++;
		}

		//update the texts
		timerText.text = "Time Remaining: " + PersistentData.timer;
		scoreText.text = "Score: " + PersistentData.score;
	}

	IEnumerator DecreaseTick() {
		while (PersistentData.timer > 0) {
			yield return new WaitForSeconds (1);
			PersistentData.timer -= 1;
		}
	}
}
