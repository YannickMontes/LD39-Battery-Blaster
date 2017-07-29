using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public ParticleSystem flash_UL;
	public ParticleSystem flash_UR;
	public ParticleSystem flash_LL;
	public ParticleSystem flash_LR;
	public GameObject impactEffect;
	public List<ParticleSystem> listParticles;
	public Camera fpsCamera;
	int ParticleSystemIndex= 0;

	void Start(){
		listParticles = new List<ParticleSystem> ();
		listParticles.Add (flash_UL);
		listParticles.Add (flash_UR);
		listParticles.Add (flash_LL);
		listParticles.Add (flash_LR);
	
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
			
	}

	void Shoot(){
		
		listParticles[ParticleSystemIndex].Play ();

		if (ParticleSystemIndex < listParticles.Count-1)
			ParticleSystemIndex++;
		else
			ParticleSystemIndex = 0;



		RaycastHit hitPoint;
		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hitPoint, range)) {
			Debug.Log (hitPoint.transform.name);

			Target target = hitPoint.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}

			GameObject impactGO = Instantiate (impactEffect, hitPoint.point, Quaternion.LookRotation (hitPoint.normal));
			//Destroy (impactGO, 2);
		}

	}


}
