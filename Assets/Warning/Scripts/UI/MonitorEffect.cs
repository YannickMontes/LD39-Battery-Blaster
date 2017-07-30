using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorEffect : MonoBehaviour {

    public float minSpeed = 0.1f;
    public float maxSpeed = 1f;
    public float maxRectsOnScreen = 20f;
    public Texture texture;
    public float heightMultiplier = 0.15f;
    public bool goUp = false;

    private List<BoxEffect> boxes = new List<BoxEffect>();
    
    private class BoxEffect {
        public Rect rect;
        public float speed;
        public BoxEffect(Rect rect, float speed) {
            this.rect = rect;
            this.speed = speed;
        }
    }

    private void Start() {
        for (int i = 0; i < maxRectsOnScreen; i++) {
            float boxHeight = GetRandomHeight();
            boxes.Add(new BoxEffect(new Rect(0, GetRandomPos(boxHeight), Screen.width, boxHeight), GetRandomSpeed()));
        }
    }

    private void Update() {
        if (boxes.Count < maxRectsOnScreen) {
            float boxHeight = GetRandomHeight();
            if (goUp == false) {
                boxes.Add(new BoxEffect(new Rect(0, -boxHeight, Screen.width, boxHeight), GetRandomSpeed()));
            } else {
                boxes.Add(new BoxEffect(new Rect(0, boxHeight + Screen.height, Screen.width, boxHeight), GetRandomSpeed()));
            }
        }
        foreach (BoxEffect box in boxes) {
            box.rect = new Rect(box.rect.x, box.rect.y + box.speed * Time.deltaTime, box.rect.width, box.rect.height);
        }
    }

    private void OnGUI() {
        foreach(BoxEffect box in boxes) {
            GUI.DrawTexture(box.rect, texture);
            if (goUp == false) {
                if (box.rect.y > (Screen.height + box.rect.height) * 1.05f) {
                    StartCoroutine(RemoveBox(box));
                }
            } else {
                if (box.rect.y < (0 - box.rect.height) * 1.05f) {
                    StartCoroutine(RemoveBox(box));
                }
            }
        }
    }

    private IEnumerator RemoveBox(BoxEffect box) {
        yield return new WaitForEndOfFrame();
        boxes.Remove(box);
    }

    private float GetRandomSpeed() {
        if (goUp == false) {
            return (minSpeed + Random.value) * maxSpeed;
        } else {
            return (minSpeed + Random.value) * maxSpeed * -1f;
        }
    }

    private float GetRandomPos(float boxHeight) {
        return -boxHeight + (Random.value * Screen.height);
    }

    private float GetRandomHeight() {
        return ((0.02f + Random.value) * heightMultiplier) * Screen.height;
    }

}
