using UnityEngine;
using System.Collections;

public class GreenCube : MonoBehaviour {

	// Green cube increase the stamina regeneration
	bool isInside;
	GameObject player;
	PlayerStamina playerStamina;

	void Awake(){
		player = GameObject.FindWithTag("Player");
		playerStamina = player.GetComponent<PlayerStamina>();

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
			playerStamina.RestoreStamina();
		}
	}
}
