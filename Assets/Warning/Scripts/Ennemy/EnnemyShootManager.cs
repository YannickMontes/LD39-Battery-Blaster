using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShootManager : MonoBehaviour {

	bool shoot = false;
	public float range = 10.0f;
	public float delay = 2.0f;
	public float damage = 1.0f;
	// Use this for initialization
	void Start () {
		
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
		Debug.Log ("pan");
		Terminator.GetTerminator ().DecreaseHP (damage);
	}
}
