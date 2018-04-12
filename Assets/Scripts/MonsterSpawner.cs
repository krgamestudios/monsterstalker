using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
	public GameObject monsterPrefab;
	public GameObject monsterPrefab2;
	public GameObject monsterPrefab3;
	public GameObject monsterPrefab4;
	public Vector2 motion;
	public float delay;

	AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();

		if (monsterPrefab2 == null) {
			monsterPrefab2 = monsterPrefab;
		}
		if (monsterPrefab3 == null) {
			monsterPrefab3 = monsterPrefab;
		}
		if (monsterPrefab4 == null) {
			monsterPrefab4 = monsterPrefab;
		}

		StartCoroutine (SpawnMonster ());
	}

	IEnumerator SpawnMonster() {
		while(true) {
			yield return new WaitForSeconds (delay);
			GameObject monster = Instantiate (monsterPrefab);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			audioSource.Play ();

			//ugly duplication
			yield return new WaitForSeconds (delay);
			monster = Instantiate (monsterPrefab2);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			audioSource.Play ();

			yield return new WaitForSeconds (delay);
			monster = Instantiate (monsterPrefab3);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			audioSource.Play ();

			yield return new WaitForSeconds (delay);
			monster = Instantiate (monsterPrefab4);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			audioSource.Play ();
		}
	}
}
