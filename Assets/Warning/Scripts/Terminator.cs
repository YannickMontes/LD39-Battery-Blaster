using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    public Stat hp;
    public Stat energy;

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

    void OnGUI()
    {
        GUI.Label(new Rect(20, 10, 100, 20), "HP: "+this.hp.CurrentValue);
        GUI.Label(new Rect(20, 30, 200, 20), "ENERGY: " + this.energy.CurrentValue);
    }
}
