using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    private void Awake() {
        Invoke("Disable", 1f);
    }

    private void Disable() {
        gameObject.SetActive(false);
    }
        

}
