using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAgent : MonoBehaviour {

    public Transform agent;
    public float moveSpeed = 5.0f;
    public float distanceToAgent = 5.0f;
    private Rigidbody body;

    // Use this for initialization
    void Start ()
    {
        this.body = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float bonus = 0.0f;
        float distance = Vector3.Distance(this.transform.position, this.agent.position);
        if (distance > 50.0f)
        {
            bonus = 4;
        }
        if (Vector3.Distance(this.transform.position, this.agent.position) > distanceToAgent)
        {
            Vector3 direction = agent.transform.position - this.transform.position;
            direction = direction.normalized;
            body.MovePosition(transform.position + (direction * Time.deltaTime * moveSpeed * bonus));
        }  
    }
}
