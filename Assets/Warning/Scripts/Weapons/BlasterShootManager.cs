using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShootManager : MonoBehaviour {
	public float energyCostPerSec = 0.8f;
	public float damage = 10f;
	public float range = 100f;

    public GameObject particlesFireSpark;
    public GameObject flashGo;
    private ParticleSystem flash;
	public Transform flash_position_UR;
	public Transform flash_position_LL;
	public Transform flash_position_LR;
	public Transform flash_position_UL;

	public GameObject impactEffect;
	public List<Transform> listParticlesPosition;

	public Camera fpsCamera;
	int ParticleSystemIndex= 0;
	public float delay = 0.3f;

	bool isCoroutineActive = false;

    private Light laserLight;


	void Start(){
		listParticlesPosition = new List<Transform> ();
		listParticlesPosition.Add (flash_position_UL);
		listParticlesPosition.Add (flash_position_UR);
		listParticlesPosition.Add (flash_position_LL);
		listParticlesPosition.Add (flash_position_LR);
        flash = GameObject.Instantiate(flashGo).GetComponent<ParticleSystem>();
        laserLight = flash.gameObject.GetComponent<Light>();

    }
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")  && !isCoroutineActive && !Terminator.GetTerminator().isRecharging){
			StartCoroutine(StartShooting());
		}

		if (Terminator.GetTerminator ().energy.CurrentValue <= 0 && flash.isPlaying) {
			Stop ();
		}
	}

	IEnumerator StartShooting() {
		isCoroutineActive = true;
		while (Input.GetButton("Fire1") && Terminator.GetTerminator().energy.CurrentValue > 0 && !Terminator.GetTerminator().isRecharging) {
			Invoke("Stop", delay);
			SoundManager.instance.playSingle (SoundManager.instance.efxBlasterSource.clip);
			Shoot ();
            yield return new WaitForSeconds(delay);
		}
		isCoroutineActive = false;
	}

	void Stop(){
		flash.Stop ();
        flash.Clear();
        laserLight.enabled = false;
    }

	void Shoot(){
		flash.transform.position = listParticlesPosition[ParticleSystemIndex].position;
		flash.transform.forward = listParticlesPosition [ParticleSystemIndex].forward;
		flash.Play ();
        laserLight.enabled = true;
        GameObject sparks = ParticlePooler.current.GetPooledObject();
        sparks.transform.position = listParticlesPosition[ParticleSystemIndex].position;
        sparks.transform.SetParent(listParticlesPosition[ParticleSystemIndex]);
        StartCoroutine(Tools.DisableCortoutine(sparks, 1f));

        if (ParticleSystemIndex < listParticlesPosition.Count-1)
			ParticleSystemIndex++;
		else
			ParticleSystemIndex = 0;

		Terminator.GetTerminator ().DecreaseEnergy (energyCostPerSec);

		RaycastHit hitPoint;
		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hitPoint, range, ~(1<<8))) {
			Target target = hitPoint.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}

            foreach (Transform t in listParticlesPosition) {
                t.LookAt(hitPoint.point);
            }
            GameObject impactGO = Instantiate (impactEffect, hitPoint.point, Quaternion.LookRotation (hitPoint.normal));
            Destroy (impactGO, 0.5f);
		}

	}


}
