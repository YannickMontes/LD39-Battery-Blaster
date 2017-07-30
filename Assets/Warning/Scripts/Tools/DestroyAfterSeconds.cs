using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    public float delay = 0.15f;

    private void Start() {
        Destroy(gameObject, delay);
    }

}
