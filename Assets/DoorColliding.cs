using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliding : MonoBehaviour {

    public EnnemyNavMeshAgent bigBossAgent;
    public GameObject door;

	// Use this for initialization
	void Start () {
        door = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (door == null || !door.activeInHierarchy)
        {
            bigBossAgent.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            bigBossAgent.target = door.transform;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Door")
        {
            door = collision.collider.gameObject;
        }
    }
}
