using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public ParticleSystem flash;

	public Camera fpsCamera;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
			
	}

	void Shoot(){
		flash.Play ();


		RaycastHit hitPoint;
		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hitPoint, range)) {
			Debug.Log (hitPoint.transform.name);

			Target target = hitPoint.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}
		}

	}


}
