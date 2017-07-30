using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public bool lookAtMainCamera;
    public GameObject target;

	void Update () {
        if (lookAtMainCamera) {
            this.transform.LookAt(Camera.main.transform);
        } else {
            this.transform.LookAt(target.transform);
        }
	}
}
