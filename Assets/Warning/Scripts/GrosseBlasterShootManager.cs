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
	bool isShooting = false;
	bool isLoading = false;
	public float damagePerTic = 5f;
	public float ticsDelay = 0.5f;
	int iterations = 30;
	public float upperSize = 1.0f;
	public float sideSize = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire3")  && Terminator.GetTerminator().energy.CurrentValue > 0 && !isShooting) {
			isLoading = true;
			downTime = Time.time;
			StartCoroutine(StartLoading());
		}
			


		if (Input.GetButtonUp("Fire3") && !isShooting && isLoading) {
			flashCharge.Stop ();
			isShooting = true ;
			isLoading = false;
			upTime = Time.time;
			pressTime = upTime - downTime;
			Invoke("Stop", pressTime);
			StartCoroutine(StartShooting());
		}
			
		
	}

	IEnumerator StartLoading() {
		while (Input.GetButton("Fire3") && Terminator.GetTerminator().energy.CurrentValue > 0) {
			flashCharge.Play ();
			Terminator.GetTerminator ().DecreaseEnergy (CostPerSec);
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator StartShooting() {
		while (isShooting ) {
			flashShoot.Play ();
			Shoot ();
			yield return new WaitForSeconds(ticsDelay);
		}
	}

	void Shoot(){
		List<Target> targets = new List<Target> ();

		List<RaycastHit> hits = new List<RaycastHit>();
		RaycastHit[] tmpHits;

		tmpHits = Physics.RaycastAll (fpsCamera.transform.position, fpsCamera.transform.forward, range);
		hits.AddRange (tmpHits);


		for (int i = 0; i < iterations/4; i++) {
			tmpHits = Physics.RaycastAll (fpsCamera.transform.position+ new Vector3 (Random.Range (0, +sideSize), Random.Range(0,+upperSize),0), fpsCamera.transform.forward, range);
			hits.AddRange (tmpHits);
			tmpHits = Physics.RaycastAll (fpsCamera.transform.position+ new Vector3 (Random.Range (0, -sideSize), Random.Range(0,+upperSize),0), fpsCamera.transform.forward, range);
			hits.AddRange (tmpHits);
			tmpHits = Physics.RaycastAll (fpsCamera.transform.position+ new Vector3 (Random.Range (0, +sideSize), Random.Range(0,-upperSize),0), fpsCamera.transform.forward, range);
			hits.AddRange (tmpHits);
			tmpHits = Physics.RaycastAll (fpsCamera.transform.position+ new Vector3 (Random.Range (0, -sideSize), Random.Range(0,-upperSize),0), fpsCamera.transform.forward, range);
			hits.AddRange (tmpHits);
		}


			

		foreach (RaycastHit hit in hits) {
			Target target = hit.transform.GetComponent<Target> ();
			if (targets != null) {
				if (target != null) {
					if (!targets.Contains (target)) {
						Debug.Log ("tape.");
						targets.Add (target);
					}
				}
			}
			
		}

		if (targets != null) {
			foreach (Target target in targets) {
				if (target != null) {
					Debug.Log ("hit.");
					target.TakeDamage (damagePerTic);
				}
			}
			targets.Clear ();
		}
		
	}
		

	void Stop(){
		flashShoot.Stop ();
		isShooting = false;
	}
}
