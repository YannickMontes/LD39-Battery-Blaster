using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryColor : MonoBehaviour {

    public Transform lowBattery;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Terminator.GetTerminator().energy.CurrentValue <= 30)
        {
            this.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
            lowBattery.gameObject.SetActive(true);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
            lowBattery.gameObject.SetActive(false);
        }
    }
}
