using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    public Stat hp;
    public Stat energy;
    public float radarRadius;

    public bool isAlive;

	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        DecreaseEnergy(); 
	}

    private void DecreaseEnergy()
    {
        this.energy.CurrentValue -= 1f;
    }

    private void CheckForEnnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 20.0f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Ennemy")
            {
                return;
            }
            i++;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 10, 100, 20), "HP: "+this.hp.CurrentValue);
        GUI.Label(new Rect(20, 30, 200, 20), "ENERGY: " + this.energy.CurrentValue);
    }
}
