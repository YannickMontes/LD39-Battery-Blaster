using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrosseBlasterShootManager : MonoBehaviour {

	float downTime, upTime, pressTime = 0;
	public float CostPerSec = 10.0f;
	public ParticleSystem flashCharge;
	public ParticleSystem flashShoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire3")  && Terminator.GetTerminator().energy.CurrentValue > 0) {
			downTime = Time.time;
			StartCoroutine(StartShooting());
		}
			


		if (Input.GetButtonUp("Fire3")) {
			flashCharge.Stop ();
			upTime = Time.time;
			pressTime = upTime - downTime;
			Shoot ();
		}
		
	}

	IEnumerator StartShooting() {
		while (Input.GetButton("Fire3") && Terminator.GetTerminator().energy.CurrentValue > 0) {
			flashCharge.Play ();
			Terminator.GetTerminator ().DecreaseEnergy (CostPerSec);
			yield return new WaitForSeconds(1.0f);
		}
	}

	void Shoot(){
		flashShoot.Play ();
		Invoke("Stop", pressTime);
	}
		

	void Stop(){
		flashShoot.Stop ();
	}
}
