using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyNavMeshAgent : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    public bool stopChase;
    private bool move;

	// Use this for initialization
	void Start () {
        move = true;
        stopChase = false;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!stopChase)
        {
            if (move)
                agent.SetDestination(target.position);

            float dist = agent.remainingDistance;
            if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0 && target.tag != "Player")
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }
        }  
    }
}
