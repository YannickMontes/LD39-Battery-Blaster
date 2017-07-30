using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouloirCreator : MonoBehaviour {

    public float width = 10.0f;
    public float length = 50.0f;
    public float height = 15.0f;
    public float rotation = 0.0f;

	// Use this for initialization
	void Start ()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.parent = this.transform;
        ground.transform.localPosition = Vector3.zero;
        ground.transform.localScale = new Vector3((width/10) + 0.2f, 1.0f, (length/ 10));

        GameObject wallRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallRight.transform.parent = this.transform;
        wallRight.transform.localPosition = new Vector3(width / 2 + 0.5f, height / 2, 0.0f);
        wallRight.transform.localScale = new Vector3(1.0f, height, length);

        GameObject wallLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallLeft.transform.parent = this.transform;
        wallLeft.transform.localPosition = new Vector3((width / 2 + 0.5f)*(-1.0f), height / 2, 0.0f);
        wallLeft.transform.localScale = new Vector3(1.0f, height, length);

        GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
        roof.transform.parent = this.transform;
        roof.transform.localPosition = new Vector3(0.0f, height + 0.5f, 0.0f);
        roof.transform.localScale = new Vector3(width + 2.0f, 1.0f, length);

        this.transform.Rotate(new Vector3(0.0f, rotation, 0.0f), Space.World);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
