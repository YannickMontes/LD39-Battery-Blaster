using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownTransform : MonoBehaviour {

    public float limitUp;
    public float limitDown;
    public bool up;

	// Use this for initialization
	void Start () {
        up = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (up)
        {
            if (this.transform.position.y < this.limitUp)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else
            {
                this.up = false;
            }
        }
        else
        {
            if (this.transform.position.y > this.limitDown)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime);
            }
            else
            {
                this.up = true;
            }
        }
	}
}
