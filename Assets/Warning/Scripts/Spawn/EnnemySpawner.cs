using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                GameObject en = Instantiate(ennemy);
                en.GetComponent<EnnemyMovement>().onlyChase = true;
                en.transform.position = new Vector3(this.transform.position.x, Random.Range(1, 7), this.transform.position.z);
                en.transform.LookAt(Terminator.GetTerminator().transform);
                en.GetComponent<Target>().SetDoorKeeper(this.doorKeeper);
                doorKeeper.AddToEnnemiesInRoom(en);
            }
            currentGeneration++;
        }
    }

    public void TurnGenerateOn()
    {
        this.canGenerate = true;
    }
}
