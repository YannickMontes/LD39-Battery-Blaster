using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource efxBlasterSource;
	public AudioSource efxRokketSource;
	public AudioSource efxGBlasterLoadSource;
	public AudioSource efxGBlasterShootSource;
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
		efxBlasterSource.clip = clip;
		efxBlasterSource.Play ();
	}

	public void RandomizeSfx(params AudioClip [] clips){
		
		int randomIndex = 0;//Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxBlasterSource.pitch = randomPitch;
		efxBlasterSource.clip = clips [randomIndex];
		efxBlasterSource.Play ();

	}



}
