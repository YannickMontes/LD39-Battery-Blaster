using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrosseBlasterShootManager : MonoBehaviour {

	float downTime, upTime, pressTime = 0;
	public float CostPerSec = 10.0f;
	public GameObject flashCharge;
	public GameObject flashShoot;
    public GameObject hitParticleEffectPrefab;
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

    private Light chargeLight;
    private ParticleSystem chargeParticlesSystem;
    private GameObject hitParticleEffectGo;

    // Use this for initialization
    void Start () {
        flashShoot.SetActive(false);
        flashCharge.SetActive(false);
        chargeLight = flashCharge.GetComponentInChildren<Light>();
        chargeParticlesSystem = flashCharge.GetComponentInChildren<ParticleSystem>();
        hitParticleEffectGo = GameObject.Instantiate(hitParticleEffectPrefab);
        hitParticleEffectGo.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire3") && Terminator.GetTerminator().energy.CurrentValue > 0 && !isShooting && !Terminator.GetTerminator().isRecharging) {
            isLoading = true;
            downTime = Time.time;
            StartCoroutine(StartLoading());

        }


        if (Input.GetButton("Fire3") && Terminator.GetTerminator().energy.CurrentValue > 0 && !isShooting && !Terminator.GetTerminator().isRecharging) {
            float amountPower = Time.time - downTime;
            chargeLight.intensity = Mathf.Clamp(amountPower * 0.5f, 0, 2f);
            chargeParticlesSystem.startSize = Mathf.Clamp(amountPower * 0.5f, 0, 2f);
        }

        if (isShooting) {
            RaycastHit[] hits = Physics.RaycastAll(fpsCamera.transform.position, fpsCamera.transform.forward, range);
            if (hits.Length >= 1 && hits[0].collider != null) {
                hitParticleEffectGo.transform.position = hits[0].point;
                hitParticleEffectGo.SetActive(true);
                hitParticleEffectGo.GetComponent<ParticleSystem>().loop = true;
                foreach (Light light in hitParticleEffectGo.GetComponentsInChildren<Light>()) {
                    light.enabled = true;
                }
            }
            else {
                hitParticleEffectGo.SetActive(false);
            }
        }


        if ( (Input.GetButtonUp("Fire3") && isLoading) || (isLoading && Terminator.GetTerminator().energy.CurrentValue <= 0) || (isLoading && Terminator.GetTerminator().isRecharging)) {
            flashCharge.SetActive(false);
			isShooting = true ;
			isLoading = false;
			upTime = Time.time;
			pressTime = upTime - downTime;
			Invoke("Stop", pressTime);
			StartCoroutine(StartShooting());
		}			
		
	}

	IEnumerator StartLoading() {
		while (Input.GetButton("Fire3") && Terminator.GetTerminator().energy.CurrentValue > 0 && !Terminator.GetTerminator().isRecharging) {
            flashCharge.SetActive(true);
			SoundManager.instance.playSingle (SoundManager.instance.efxGBlasterLoadSource.clip);
            Terminator.GetTerminator ().DecreaseEnergy (CostPerSec);			
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator StartShooting() {
		while (isShooting ) {
			flashShoot.SetActive(true);
			SoundManager.instance.playSingle (SoundManager.instance.efxGBlasterShootSource.clip);
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
						targets.Add (target);
					}
				}
			}
			
		}

		if (targets != null) {

            foreach (Target target in targets) {
				if (target != null) {
					target.TakeDamage (damagePerTic);
				}
			}
			targets.Clear ();
		}
		
	}
		

	void Stop() {
        flashShoot.SetActive(false);
        isShooting = false;
        StartCoroutine(DisableHitEffect());
        foreach(Light light in hitParticleEffectGo.GetComponentsInChildren<Light>()) {
            light.enabled = false;
        }
    }

    private IEnumerator DisableHitEffect() {
        hitParticleEffectGo.GetComponent<ParticleSystem>().loop = false;
        yield return new WaitForSeconds(0.5f);
        if (isShooting == false) {
            hitParticleEffectGo.SetActive(false);
        }
    }
}
