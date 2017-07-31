using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public GameObject VictoryPanel;
	public GameObject GOPanel;
	static GameManager GameManagerCurrent;
	public Text score;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	public float timer =0;
	float StartTimer=0;
	float EndTimer=0;
	bool endGame = false;
	// Use this for initialization
	void Start () {
		VictoryPanel.SetActive (false);
		GOPanel.SetActive (false);
		GameManagerCurrent = this;
		StartTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (BigBossManager.bbm == null && !endGame) {
			Victory ();
		}
		if (BigBossManager.bbm.lifePoints <= 0 && !endGame) {
			Victory ();
		}*/

		if (Terminator.GetTerminator ().hp <= 0 && !endGame) {
			GameOver ();
		}
	}

	public static GameManager GetGameManager(){
		return GameManagerCurrent;
	}

	public void Victory(){
		endGame = true;
		EndTimer = Time.time;
		timer = EndTimer - StartTimer;
		if (!VictoryPanel.activeSelf) {
			VictoryPanel.SetActive (true);
			string s = timer.ToString()+" secondes";
			score.text = s;
		}
	}

	public void GameOver(){
		controller.enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		endGame = true;
		EndTimer = Time.time;
		timer = EndTimer - StartTimer;
		if (!GOPanel.activeSelf) {
			GOPanel.SetActive (true);
		}
	}


}
