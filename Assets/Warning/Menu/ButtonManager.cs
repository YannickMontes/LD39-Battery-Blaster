using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
	public AudioClip clic;

	public void newGameButton(string newGameLevel){
		SoundManager.instance.RandomizeSfx (clic);
		SceneManager.LoadScene (newGameLevel);
	}
		
	public void exitGameButton(){
		Application.Quit ();
	}
}
