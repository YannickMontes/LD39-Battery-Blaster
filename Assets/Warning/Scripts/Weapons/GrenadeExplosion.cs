using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {
	public float grenadeExplosiveDelay = 2.0f;
	public float radius = 30.0f;

	public float damageMax = 1f;

	public GameObject impactEffect;

	public float grenadeExplosivePower = 1.0f;
	// Use this for initialization
	void Start () {
		Invoke("Boom", grenadeExplosiveDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void Boom(){

		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);

		GameObject impactGO = Instantiate (impactEffect, transform.position, Quaternion.LookRotation (Vector3.up));
		Destroy (impactGO, 2);

		foreach( Collider col in colliders){
			if (col.GetComponent<Rigidbody>()) {
				col.GetComponent<Rigidbody>().AddExplosionForce (grenadeExplosivePower, transform.position, radius, 1.0f);
				Target target = col.gameObject.GetComponent<Target> ();
				if (target != null) {
					float damage = Mathf.Clamp(radius-Vector3.Distance (this.transform.position, target.transform.position),0,radius);
					target.TakeDamage (damage);
				}
					Destroy (gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision col){
		Joint grenadeSticky = gameObject.AddComponent (typeof( FixedJoint)) as Joint;
		grenadeSticky.connectedBody = col.rigidbody;
	}



}
