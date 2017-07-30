using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public bool gIsDown;
    public float rollingFaceLimit;
    public float energyGain;

	// Use this for initialization
	void Start ()
    {
        gIsDown = false;
        InvokeRepeating("CheckRollingFaceRate", 0.0f, rollingFaceLimit);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!gIsDown && Input.GetKeyDown(KeyCode.G))
        {
            gIsDown = true;
        }
        else if (gIsDown && Input.GetKeyDown(KeyCode.H))
        {
            gIsDown = false;
            this.gameObject.GetComponent<Terminator>().energy.CurrentValue += energyGain;
        }
	}

    private void CheckRollingFaceRate()
    {
        if(gIsDown)
            gIsDown = false;
    }
}
