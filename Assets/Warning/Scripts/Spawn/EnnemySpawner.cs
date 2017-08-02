using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemySpawner : MonoBehaviour {

    public GameObject ennemy;
    public DoorKeeper doorKeeper;
    public bool canGenerate;
    public int maxGeneration;
    public float beginTime;
    public int currentGeneration;
    public float spawnDelay = 2.0f;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", beginTime, spawnDelay);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void Spawn()
    {
        if (canGenerate)
        {
            if (currentGeneration >= maxGeneration)
            {
                CancelInvoke();
            }
            else
            {
                GameObject en = Instantiate(ennemy, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), Quaternion.identity);
                Transform drone = en.transform.Find("Drone");
                drone.localPosition = Vector3.up * Random.Range(1.5f, 6.0f);
                drone.GetComponent<Target>().SetDoorKeeper(this.doorKeeper);
                AddSpawnedEnnemyToDoorKeeper(drone.gameObject);
            }
            currentGeneration++;
        }
    }

    private void AddSpawnedEnnemyToDoorKeeper(GameObject go)
    {
        if(doorKeeper != null)
            doorKeeper.AddToEnnemiesInRoom(go);
    }

    public void TurnGenerateOn()
    {
        this.canGenerate = true;
    }
}
