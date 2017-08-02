using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f;
    private DoorKeeper doorKeeper;
	public bool isBoss = false;
	public bool isPlayer = false;
    public GameObject boomParticlesEffectPrefab;

	public void TakeDamage(float amount){
		if (isBoss) {
			if (!BigBossManager.getBBM().invulnerable ) {
				health -= amount;
				if (health <= 0f) {
					Die ();
				}
			}
		} else if(!isPlayer){
			health -= amount;
			if (health <= 0f) {
				Die ();
			}
		}


	}

	void Die(){
        if(doorKeeper!= null)
            doorKeeper.RemoveFromEnnemiesInRoom(this.gameObject);
        if (boomParticlesEffectPrefab != null)
        {
            GameObject boom = GameObject.Instantiate(boomParticlesEffectPrefab);
            boom.transform.position = transform.position;
            Destroy(boom, 3f);
        }
        EnnemyShootManager shootManager = this.GetComponent<EnnemyShootManager>();
        if (shootManager != null)
        {
            shootManager.DestroyParticles();
        }
        if (this.transform.parent != null && this.gameObject.tag != "Objective")
            Destroy(gameObject.transform.parent.gameObject);
        else
            Destroy(gameObject);
	}

    public void SetDoorKeeper(DoorKeeper door)
    {
        this.doorKeeper = door;
    }
}
