using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour {

    private Transform player;

    public bool isChasing;

	// Use this for initialization
	void Start ()
    {
        isChasing = false;
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckForPlayer();

        Move();
    }

    private void Move()
    {
        if (isChasing)
            Chase();
        else
            MoveNormaly();
    }

    private void MoveNormaly()
    {

    }

    private void Chase()
    {
        Vector3 playerDirection = player.position - this.transform.position;
        this.transform.Translate(playerDirection * Time.deltaTime);
    }

    private void CheckForPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 20.0f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                isChasing = true;
                return;
            }
            i++;
        }
        isChasing = false;
    }
}
