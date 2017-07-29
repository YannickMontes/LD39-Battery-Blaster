using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RokketShootManager : MonoBehaviour {
	public float energyCost = 10f;
	public float damage = 50f;
	public float range = 60f;

	public ParticleSystem flash;
	public GameObject impactEffect;


	public Camera fpsCamera;

	public float delay = 1f;




	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2")){
			StartCoroutine(StartShooting());
		}	


	}

	IEnumerator StartShooting() {

		while (Input.GetButton("Fire2")) {
			Shoot ();
			yield return new WaitForSeconds(delay);
		}
	}

	void Shoot(){
		flash.Play ();

		Terminator.GetTerminator ().DecreaseEnergy (energyCost);

		RaycastHit hitPoint;
		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hitPoint, range)) {
			Target target = hitPoint.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}

			GameObject impactGO = Instantiate (impactEffect, hitPoint.point, Quaternion.LookRotation (hitPoint.normal));
			Destroy (impactGO, 2);
		}

	}


}
