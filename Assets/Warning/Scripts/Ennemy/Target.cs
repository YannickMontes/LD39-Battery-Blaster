﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f;
    private DoorKeeper doorKeeper;

	public void TakeDamage(float amount){
		health -= amount;
		if (health <= 0f) {
			Die ();
		}
	}

	void Die(){
        if(doorKeeper!= null)
            doorKeeper.RemoveFromEnnemiesInRoom(this.gameObject);
		Destroy (gameObject);
	}

    public void SetDoorKeeper(DoorKeeper door)
    {
        this.doorKeeper = door;
    }
}