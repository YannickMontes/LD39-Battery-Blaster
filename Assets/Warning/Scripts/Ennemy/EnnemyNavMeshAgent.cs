using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyNavMeshAgent : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    private bool move;

	// Use this for initialization
	void Start () {
        move = true;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(move)
            agent.SetDestination(target.position);
	}
}
