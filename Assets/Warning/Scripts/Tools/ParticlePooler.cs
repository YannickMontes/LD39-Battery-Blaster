using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePooler : AbstractObjectPooler {
    public static ParticlePooler current;

    public void Awake() {
        ParticlePooler.current = this;
    }
}
