using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource russianSource;
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

	public void playBlaster(){
		RandomizeSfx (efxBlasterSource);
	}

	public void playRokket(){
		RandomizeSfx (efxRokketSource);
	}

	public void playGBlasterLoad(){
		efxGBlasterLoadSource.Play();
	}

	public void stopGBlasterLoad(){
		efxGBlasterLoadSource.Stop();
	}

	public void playGBlasterShoot(){
		efxGBlasterShootSource.Play();
	}

	public void RandomizeSfx(AudioSource clip){
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		clip.pitch = randomPitch;
		clip.Play ();

	}



}
