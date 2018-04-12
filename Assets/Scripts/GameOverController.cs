using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
	public Text scoreText;
	public Text creditText;
	public Text clickText;
	public GameObject background;

	Dictionary<string, GameObject> objectSet;

	bool open = false;
	int page = -1;

	void Awake() {
		objectSet = new Dictionary<string, GameObject> ();

		//prune "(clone)" from each monster name
		HashSet<string> hs = new HashSet<string> ();
		foreach(string str in PersistentData.monsterNames) {
			hs.Add (str.Split ('(') [0]);
		}
		PersistentData.monsterNames = hs;

		//load each image
		float posX = 12.1f;
		foreach(string str in PersistentData.monsterNames) {
			Sprite spr = Resources.Load ("photos/" + str, typeof(Sprite)) as Sprite;
			GameObject obj = new GameObject ();
			obj.AddComponent<SpriteRenderer> ();
			obj.GetComponent<SpriteRenderer> ().sprite = spr;
			obj.transform.localScale = new Vector3 (0.25f, 0.25f, 1f);
			obj.transform.position = new Vector3 (posX, 0, 0);
			objectSet.Add (str, obj);

			//increment
			posX += 8.05f; //NOTE: code duplication
		}

		//pause the background animation
		background.GetComponent<Animator>().speed = 0;
	}

	void Update() {
		//get the x & y of the mouse as a ratio
		float mouseX = Input.mousePosition.x / Screen.width;
		float mouseY = Input.mousePosition.y / Screen.height;

		if (Input.GetButtonDown ("Quit")) {
			Application.Quit ();
		}

		if (Input.GetMouseButtonDown(0)) {
			if (mouseX < 0.5f && page > 0) {
				JumpRight ();
				page--;
			}
			if (mouseX >= 0.5f && page < (objectSet.Count -1)/2) {
				if (open == false) {
					open = true;
					//TODO: animate the background
					background.GetComponent<Animator>().speed = 1;


					StartCoroutine (OpeningCoroutine ());
					return;
				}
				JumpLeft ();
				page++;
			}
		}
	
		//update the texts
		if (open == false) {
			scoreText.text = "Player's Score:       " + PersistentData.score + "\n";
			scoreText.text += "Camera Clicks:        " + PersistentData.clicks + "\n";
			scoreText.text += "Monsters Captured: " + PersistentData.monsterNames.Count + "/4";
		} else {
			scoreText.enabled = false;
			creditText.enabled = false;
			clickText.enabled = false;
		}
	}

	IEnumerator OpeningCoroutine() {
		yield return new WaitForSeconds (0.75f);
		background.GetComponent<Animator> ().Play ("ending_opening", 0, 1f);
		background.GetComponent<Animator> ().speed = 0;
		JumpLeft ();
		page++;
	}

	void JumpLeft() {
		foreach(KeyValuePair<string, GameObject> pair in objectSet) {
			pair.Value.transform.position = new Vector3 (pair.Value.transform.position.x - 16.1f, 0.5f, 0);
		}
	}

	void JumpRight() {
		foreach(KeyValuePair<string, GameObject> pair in objectSet) {
			pair.Value.transform.position = new Vector3 (pair.Value.transform.position.x + 16.1f, 0.5f, 0);
		}
	}
}
