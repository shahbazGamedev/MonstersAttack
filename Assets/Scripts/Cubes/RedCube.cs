using UnityEngine;
using System.Collections;

public class RedCube : MonoBehaviour {

	// Red cube is a healing cube acting only in the radius of the children collider

	public 	bool isInside;
	GameObject player;
	PlayerHealth playerHealth;
	Renderer rend;

	void Awake(){
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		rend = GameObject.FindWithTag("RendPlayer").GetComponent<Renderer>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
		isInside = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject == player){
		isInside = false;
		}
	}

	void Update(){
		if(isInside){
			int amount = 1;
			if(playerHealth.currentHealth<100){			//If the player have health to restore
			playerHealth.currentHealth += amount;		//Perform the healing
			}
		}
	}
}
