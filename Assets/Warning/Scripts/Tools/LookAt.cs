using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public bool lookAtMainCamera;
    public bool onlyDirection;
    public GameObject target;

	void Update () {
        if (lookAtMainCamera) {
            this.transform.LookAt(Camera.main.transform);
        } else {
            if (onlyDirection)
            {
                this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
            }
            else
            {
                this.transform.LookAt(target.transform);
            }
        }
	}
}
