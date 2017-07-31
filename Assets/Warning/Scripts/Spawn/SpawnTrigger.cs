using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    public DoorKeeper doors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                EnnemySpawner spawner = this.transform.GetChild(i).GetComponent<EnnemySpawner>();
                spawner.doorKeeper = doors;
                spawner.TurnGenerateOn();
            }
            if (doors != null)
            {
                doors.gameObject.SetActive(true);
            }
        }
    }
}
