using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossManager : MonoBehaviour {


	public float lifePoints = 200f;
	public GameObject SG1;
	public GameObject SG2;
	public GameObject SG3;


	bool shield1 = true;
	bool shield2 = true;
	bool shield3 = true;

	public static BigBossManager bbm;

	public bool invulnerable = true;
	// Use this for initialization
	void Start () {
		invulnerable = true;
		shield1 = true;
		shield2 = true;
		shield3 = true;
		if (bbm != null) {
			GameObject.Destroy (bbm);
		}
		else
			bbm = this;
	}
	
	// Update is called once per frame
	void Update () {
		Target tmpTarget = SG1.GetComponentInChildren<Target> ();
		if (tmpTarget == null) {
				shield1 = false;
		}

		tmpTarget = SG2.GetComponentInChildren<Target> ();
		if (tmpTarget == null) {
				shield2 = false;
		}

		tmpTarget = SG3.GetComponentInChildren<Target> ();
		if (tmpTarget == null) {
				shield3 = false;
		}

		if (!shield1 && !shield2 && !shield3) {
			invulnerable = false;
		}
	}

	public static BigBossManager getBBM(){
		return bbm;
	}
}
