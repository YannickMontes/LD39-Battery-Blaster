﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void playSingle(AudioClip clip){
		efxSource.clip = clip;
		efxSource.Play ();
	}

	public void RandomizeSfx(params AudioClip [] clips){
		
		int randomIndex = 0;//Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource.pitch = randomPitch;
		efxSource.clip = clips [randomIndex];
		efxSource.Play ();

	}



}
