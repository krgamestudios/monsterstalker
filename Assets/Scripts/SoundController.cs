using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
	AudioSource audioSource;
	public AudioClip snapShot;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();
	}

	public void PlaySnapShot() {
		audioSource.PlayOneShot (snapShot, 1.0f);
	}
}
