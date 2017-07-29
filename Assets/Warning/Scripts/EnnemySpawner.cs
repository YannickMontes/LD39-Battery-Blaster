using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour {

    public GameObject ennemy;
    public bool canGenerate;
    public int maxGeneration;
    public int currentGeneration;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", 0.0f, 5.0f);
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
                en.transform.position = this.transform.position;
            }
            currentGeneration++;
        }
    }

    public void TurnGenerateOn()
    {
        this.canGenerate = true;
    }
}
