using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void newGameButton(string newGameLevel){
		SceneManager.LoadScene (newGameLevel);
	}
		
	public void exitGameButton(){
		Application.Quit ();
	}
}
