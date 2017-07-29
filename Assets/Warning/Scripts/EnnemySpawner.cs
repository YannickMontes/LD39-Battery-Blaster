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
                en.transform.position = new Vector3(this.transform.position.x, 2.0f, this.transform.position.z);
                en.transform.LookAt(Terminator.GetTerminator().transform);
            }
            currentGeneration++;
        }
    }

    public void TurnGenerateOn()
    {
        this.canGenerate = true;
    }
}
