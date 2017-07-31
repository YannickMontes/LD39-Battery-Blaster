using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Terminator.GetTerminator().energy.CurrentValue <= 30)
        {
            this.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
        }
    }
}
