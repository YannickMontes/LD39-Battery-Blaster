using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeeper : MonoBehaviour {

    private bool canBeUnclocked;
    private List<GameObject> ennemiesInRoom; 

	// Use this for initialization
	void Start ()
    {
        canBeUnclocked = false;
        ennemiesInRoom = new List<GameObject>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canBeUnclocked && ennemiesInRoom.Count == 0)
        {
            this.gameObject.SetActive(false);
        }
	}

    public void AddToEnnemiesInRoom(GameObject ennemy)
    {
        this.canBeUnclocked = true;
        this.ennemiesInRoom.Add(ennemy);
    }

    public void RemoveFromEnnemiesInRoom(GameObject ennemy)
    {
        this.ennemiesInRoom.Remove(ennemy);
    }
}
