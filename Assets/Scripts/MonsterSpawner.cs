using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour {
	public GameObject monsterPrefab;
	public GameObject monsterPrefab2;
	public GameObject monsterPrefab3;
	public GameObject monsterPrefab4;

	public AudioClip twigOne;
	public AudioClip twigTwo;
	public AudioClip twigThree;
	public AudioClip water;
	public bool waterSoundOnly = false;

	public Vector2 motion;
	public float delay;
	public float lifespan;

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
			monster.GetComponent<Monster> ().lifespan = lifespan;
			PlaySound ();

			//ugly duplication
			yield return new WaitForSeconds (delay);
			monster = Instantiate (monsterPrefab2);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			monster.GetComponent<Monster> ().lifespan = lifespan;
			PlaySound ();

			yield return new WaitForSeconds (delay);
			monster = Instantiate (monsterPrefab3);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			monster.GetComponent<Monster> ().lifespan = lifespan;
			PlaySound ();

			yield return new WaitForSeconds (delay);
			monster = Instantiate (monsterPrefab4);
			monster.transform.position = transform.position;
			monster.GetComponent<Rigidbody2D> ().velocity = motion;
			monster.GetComponent<Monster> ().lifespan = lifespan;
			PlaySound ();
		}
	}

	void PlaySound() {
		AudioClip audioClip = new AudioClip();

		if (waterSoundOnly) {
			audioClip = water;
		} else {
			int choice = Random.Range (0, 3);
			switch(choice) {
			case 0:
				audioClip = twigOne;
				break;
			case 1:
				audioClip = twigTwo;
				break;
			case 2:
				audioClip = twigThree;
				break;
			}
		}

		audioSource.PlayOneShot (audioClip, 0.3f);
	}
}
