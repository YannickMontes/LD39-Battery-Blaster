using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour {

	private Transform player;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	public float distanceToPlayer = 0.0f;
	public bool onlyChase;
	private bool isChasing;
	static PlayerShadow PlayerShadowCurrent;
	private float moveSpeed;
	private int direction;
	public float maxDistance = 10.0f;

	private Vector3 destination;

	// Use this for initialization
	void Start ()
	{
		isChasing = false;

		this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		this.player = this.player.GetChild (0);
		this.direction = 1;
		this.transform.position = player.position;
		this.destination = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		PlayerShadowCurrent = this;
	}

	// Update is called once per frame
	void Update ()
	{
		CheckForPlayer();
		Move();

	}

	public static PlayerShadow GetShadow(){
		return PlayerShadowCurrent;
	}


	private void Move()
	{
		moveSpeed = controller.speed-1;
		Vector3 moving;
		if (isChasing || onlyChase)
			moving = Chase();
		else
			moving = MoveNormaly();
		this.LookAtDirection(moving, 1.0f);
		if (Vector3.Distance(player.position, this.transform.position) > distanceToPlayer)
		{
			transform.position += (moving * Time.deltaTime * moveSpeed);
		}

	

		if (Vector3.Distance (player.position, this.transform.position) > maxDistance) {
			moveSpeed*=2;
		}
	
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

	private void LookAtDirection(Vector3 direction, float rotationSpeed)
	{
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
	}
}
