using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public GameObject VictoryPanel;
	static GameManager GameManagerCurrent;
	public Text score;

	public float timer =0;
	float StartTimer=0;
	float EndTimer=0;
	bool endGame = false;
	// Use this for initialization
	void Start () {
		VictoryPanel.SetActive (false);
		GameManagerCurrent = this;
		StartTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (BigBossManager.bbm == null && !endGame) {
			Victory ();
		}
		if (BigBossManager.bbm.lifePoints <= 0 && !endGame) {
			Victory ();
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
		EndTimer = Time.time;
		timer = EndTimer - StartTimer;
	}

}
