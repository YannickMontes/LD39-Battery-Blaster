using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RokketShootManager : MonoBehaviour {
	public float energyCost = 10f;

	public Rigidbody grenadeRB;
	public float grenadeLaunchPower = 10;

	public ParticleSystem flash;

	bool isCoroutineActive = false;

	public Camera fpsCamera;

	public float delay = 5f;



	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2")  && !isCoroutineActive && !Terminator.GetTerminator().isRecharging)
        {
			StartCoroutine(StartShooting());
		}	
	}

	IEnumerator StartShooting() {
		isCoroutineActive = true;
		while (Input.GetButton("Fire2") && Terminator.GetTerminator().energy.CurrentValue > 0 && !Terminator.GetTerminator().isRecharging) {
			SoundManager.instance.playSingle (SoundManager.instance.efxRokketSource.clip);
			Shoot ();
			yield return new WaitForSeconds(delay);
		}
		isCoroutineActive = false;
	}

	void Shoot(){
		flash.Play ();
		Terminator.GetTerminator ().DecreaseEnergy (energyCost);

		Rigidbody grenade = Instantiate (grenadeRB,transform.position,transform.rotation);
		grenade.velocity = transform.TransformDirection (Vector3.forward * grenadeLaunchPower);
	}
		


}
