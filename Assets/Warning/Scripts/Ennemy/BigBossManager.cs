using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossManager : MonoBehaviour {


	public float lifePoints = 200f;
	public Target SG1;
	public Target SG2;
	public Target SG3;
    public GameObject shield;
    public Transform finalDestination;
    public EnnemyNavMeshAgent navMeshAgent;


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
		if (SG1.health <= 0) {
				shield1 = false;
		}

		if (SG2.health <= 0) {
				shield2 = false;
		}

		if (SG3.health <= 0) {
				shield3 = false;
		}

		if (!shield1 && !shield2 && !shield3) {
			invulnerable = false;
            if (shield != null)
                Destroy(shield);
            navMeshAgent.target = finalDestination;
		}
	}

	public static BigBossManager getBBM(){
		return bbm;
	}
}
