using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrosseBlasterShootManager : MonoBehaviour {

	float downTime, upTime, pressTime = 0;
	public float CostPerSec = 10.0f;
	public ParticleSystem flashCharge;
	public ParticleSystem flashShoot;
	public float range = 30.0f;
	public float radius = 0.5f;
	public Camera fpsCamera;
	bool stopShooting = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire3")  && Terminator.GetTerminator().energy.CurrentValue > 0 && stopShooting) {
			downTime = Time.time;
			stopShooting = true;
			StartCoroutine(StartCharging());
		}
			


		if (Input.GetButtonUp("Fire3")) {
			flashCharge.Stop ();
			stopShooting = false;
			upTime = Time.time;
			pressTime = upTime - downTime;
		}

		if (!stopShooting) {
			StartCoroutine(StartShooting());
			Stop ();
		}
		
	}

	IEnumerator StartCharging() {
		while (Input.GetButton("Fire3") && Terminator.GetTerminator().energy.CurrentValue > 0) {
			flashCharge.Play ();
			Terminator.GetTerminator ().DecreaseEnergy (CostPerSec);
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator StartShooting() {
		while (Input.GetButton("Fire3") && !stopShooting) {
			flashShoot.Play ();
			Shoot ();
			yield return new WaitForSeconds(0.5f);
		}
	}

	void Shoot(){

		RaycastHit[] hits;
		hits = Physics.RaycastAll (fpsCamera.transform.position, fpsCamera.transform.forward, range);
		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
			Debug.Log ("looooooo "+ hit.transform.name);
		}
		
	}
		

	void Stop(){
		flashShoot.Stop ();
		stopShooting = true;
	}
}
