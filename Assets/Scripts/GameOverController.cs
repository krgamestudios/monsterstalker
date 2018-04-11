using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
	public Text scoreText;
	Dictionary<string, Sprite> spriteSet;

	GameObject leftPage;
	GameObject rightPage;

	void Awake() {
		spriteSet = new Dictionary<string, Sprite> ();

		//prune "(clone)" from each monster name
		HashSet<string> hs = new HashSet<string> ();
		foreach(string str in PersistentData.monsterNames) {
			hs.Add (str.Split ('(') [0]);
		}
		PersistentData.monsterNames = hs;

		//load each image
		foreach(string str in PersistentData.monsterNames) {
			Sprite spr = Resources.Load ("photos/" + str, typeof(Sprite)) as Sprite;
			spriteSet.Add (str, spr);
		}

		//configure the page objects
		leftPage = new GameObject ();
		rightPage = new GameObject ();
		leftPage.AddComponent<SpriteRenderer> ();
		rightPage.AddComponent<SpriteRenderer> ();

		leftPage.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
		leftPage.transform.position = new Vector3 (-5f, 0, 0);
		rightPage.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
		rightPage.transform.position = new Vector3 (5f, 0, 0);

		//test
		leftPage.GetComponent<SpriteRenderer> ().sprite = spriteSet["Nessie"] as Sprite;
		rightPage.GetComponent<SpriteRenderer> ().sprite = spriteSet["Nessie"] as Sprite;
	}

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
