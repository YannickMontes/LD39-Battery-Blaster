using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShootManager : MonoBehaviour {

	bool shoot = false;
	public float range = 10.0f;
	public float delay = 2.0f;
	public float damage = 1.0f;

	public GameObject flashGo ;
	private ParticleSystem flash_L;
	private ParticleSystem flash_R;
	public Transform flash_position_L;
	public Transform flash_position_R;


	// Use this for initialization
	void Start () {
		flash_L = GameObject.Instantiate(flashGo).GetComponent<ParticleSystem>();
		flash_R = GameObject.Instantiate(flashGo).GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(Terminator.GetTerminator().transform.position, this.transform.position) < range && !shoot){
			StartCoroutine (StartShooting ());
		}
	}

	IEnumerator StartShooting() {
		shoot = true;
		while (Vector3.Distance(Terminator.GetTerminator().transform.position, this.transform.position) < range) {
			Shoot ();
			yield return new WaitForSeconds(delay);
		}
		shoot = false;
	}

	public void Shoot(){
		flash_L.transform.position = flash_position_L.position;
		flash_L.transform.forward = flash_position_L.forward;
		flash_L.Play ();

		flash_R.transform.position = flash_position_R.position;
		flash_R.transform.forward = flash_position_R.forward;
		flash_R.Play ();

		RaycastHit hitPoint;
		Vector3 shadowPosition;
		shadowPosition = PlayerShadow.GetShadow ().transform.position;

		Vector3 aim = shadowPosition - this.transform.position;
		if (Physics.Raycast (this.transform.position, aim , out hitPoint, range, ~(1<<9))) {
			Target target = hitPoint.transform.GetComponent<Target> ();
			//Debug.Log (hitPoint.transform.position + " " + hitPoint.transform.name);
			Debug.DrawRay (this.transform.position, aim, Color.green);
			if (target != null) {
				if(target.isPlayer){
					Terminator.GetTerminator ().DecreaseHP (damage);
				}

			}
					//player screen shaken
		}
	}

    public void DestroyParticles()
    {
        Destroy(this.flash_L.gameObject);
        Destroy(this.flash_R.gameObject);
    }
}
