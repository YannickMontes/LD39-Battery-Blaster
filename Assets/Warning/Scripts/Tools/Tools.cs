using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools {
    public static IEnumerator DisableCortoutine(GameObject goToDisable, float delay) {
        yield return new WaitForSeconds(delay);
        goToDisable.SetActive(false);
    }
}
