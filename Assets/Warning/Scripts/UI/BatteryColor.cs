using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryColor : MonoBehaviour {

    public GameObject lowBattery;
    public GameObject lowBatteryText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        KeyDisplay();
        ColorHandling();
    }

    private void ColorHandling()
    {
        if (Terminator.GetTerminator().energy.CurrentValue <= 30)
        {
            this.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
            lowBattery.SetActive(true);
            lowBatteryText.SetActive(true);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
            lowBatteryText.SetActive(false);
        }
    }

    private void KeyDisplay()
    {
        if(Terminator.GetTerminator().isRecharging)
            lowBattery.SetActive(true);
        else
            lowBattery.SetActive(false);
    }
}
