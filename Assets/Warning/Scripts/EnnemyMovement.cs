﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour {

    private Transform player;

    public int moveSpeed;

    private bool isChasing;

    private int direction;

    private Vector3 destination;

	// Use this for initialization
	void Start ()
    {
        isChasing = false;
        moveSpeed = 5;
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.direction = 1;
        this.destination = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckForPlayer();

        Move();
    }

    private void Move()
    {
        Vector3 moving;
        if (isChasing)
            moving = Chase();
        else
            moving = MoveNormaly();
        if (Vector3.Distance(player.position, this.transform.position) > 2.0f)
            this.GetComponent<Rigidbody>().MovePosition(transform.position + moving * Time.deltaTime * moveSpeed);
    }

    private Vector3 MoveNormaly()
    {
        if (Vector3.Distance(this.transform.position, this.destination) < 1f && direction !=0)
        {
            StartCoroutine(WaitASecond());
        }
        if (direction == 0)
        {
            return Vector3.zero;
        }
        else if (direction == 1)
        {
            return Vector3.right;
        }
        else if (direction == -1)
        {
            return Vector3.left;
        }
        return Vector3.zero;
    }

    public IEnumerator WaitASecond()
    {
        int newDirection = this.direction*(-1);
        this.destination = new Vector3(this.transform.position.x + (10 * newDirection), this.transform.position.y, this.transform.position.z);
        this.direction = 0;
        yield return new WaitForSeconds(1);
        this.direction = newDirection;
    }

    private Vector3 Chase()
    {
        Vector3 playerDirection = player.position - this.transform.position;
        return playerDirection.normalized;
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
