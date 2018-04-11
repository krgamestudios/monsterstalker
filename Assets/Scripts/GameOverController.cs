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
		float posX = 15f;
		foreach(string str in PersistentData.monsterNames) {
			Sprite spr = Resources.Load ("photos/" + str, typeof(Sprite)) as Sprite;
			GameObject obj = new GameObject ();
			obj.AddComponent<SpriteRenderer> ();
			obj.GetComponent<SpriteRenderer> ().sprite = spr;
			obj.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
			obj.transform.position = new Vector3 (posX, 0, 0);
			objectSet.Add (str, obj);

			//increment
			posX += 10f; //NOTE: code duplication
		}
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
				}
				JumpLeft ();
				page++;
			}
		}
	
		//update the texts
		if (open == false) {
			scoreText.text = "Player's Score:       " + PersistentData.score + "\n";
			scoreText.text += "Camera Clicks:        " + PersistentData.clicks + "\n";
			scoreText.text += "Monsters Captured: " + PersistentData.monsterNames.Count + "/10";
		} else {
			scoreText.enabled = false;
			creditText.enabled = false;
			clickText.enabled = false;
		}
	}

	void JumpLeft() {
		foreach(KeyValuePair<string, GameObject> pair in objectSet) {
			pair.Value.transform.position = new Vector3 (pair.Value.transform.position.x - 20f, 0, 0);
		}
	}

	void JumpRight() {
		foreach(KeyValuePair<string, GameObject> pair in objectSet) {
			pair.Value.transform.position = new Vector3 (pair.Value.transform.position.x + 20f, 0, 0);
		}
	}
}
