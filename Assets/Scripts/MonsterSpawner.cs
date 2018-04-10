using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
	public GameObject monsterPrefab;
	public Vector2 motion;
	public float delay;

	AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();

		StartCoroutine (SpawnMonster ());
	}

	IEnumerator SpawnMonster() {
		while(true) {
			yield return new WaitForSeconds (delay);
			GameObject monster = Instantiate (monsterPrefab);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			audioSource.Play ();
		}
	}
}
