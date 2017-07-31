using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    public bool gIsDown;
    public float rollingFaceLimit;
    public float energyGain;
    public GameObject reloadingUI;
    private Image key1;
    private Image key2;
    public Color lowAlpha = new Color(1.0f, 1.0f, 1.0f, 0.25f);
    public Color highAlpha = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    // Use this for initialization
    void Start ()
    {
        gIsDown = false;
        InvokeRepeating("CheckRollingFaceRate", 0.0f, rollingFaceLimit);
        key1 = reloadingUI.transform.Find("Key1").GetComponent<Image>();
        key2 = reloadingUI.transform.Find("Key3").GetComponent<Image>();
        key1.color = highAlpha;
        key2.color = lowAlpha;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!gIsDown && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Terminator.GetTerminator().isRecharging = true;
            gIsDown = true;
            key1.color = lowAlpha;
            key2.color = highAlpha;
        }
        else if (gIsDown && Input.GetKeyDown(KeyCode.Alpha3))
        {
            gIsDown = false;
            this.gameObject.GetComponent<Terminator>().energy.CurrentValue += energyGain;
            key1.color = highAlpha;
            key2.color = lowAlpha;
        }

        // CHEAT TO REMOVE

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Terminator.GetTerminator().energy.CurrentValue = 100;
        }
	}

    private void CheckRollingFaceRate()
    {
        if (gIsDown)
        {
            gIsDown = false;
            key1.color = highAlpha;
            key2.color = lowAlpha;
        }
        Terminator.GetTerminator().isRecharging = false;
    }
}
