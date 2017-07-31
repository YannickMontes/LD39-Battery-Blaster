using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliding : MonoBehaviour {

    public EnnemyNavMeshAgent bigBossAgent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Door")
        {
            bigBossAgent.target = collision.collider.transform;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Door")
        {
            bigBossAgent.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
}
