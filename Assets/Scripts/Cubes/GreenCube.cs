using UnityEngine;
using System.Collections;

public class GreenCube : MonoBehaviour {

	//Green cube increase the stamina regeneration
	
    //Public bools
	public bool isInside;

    //Public references
	public GameObject player;
	public PlayerStamina playerStamina;

	public void Awake(){
        //Initialize components
		player = GameObject.FindWithTag("Player");
		playerStamina = player.GetComponent<PlayerStamina>();

	}

	public void OnTriggerEnter(Collider other){
        //If the player is inside
		if(other.gameObject == player){
			isInside = true;
		}
	}

	public void OnTriggerExit(Collider other){
        //If the player isnt inside
		if(other.gameObject == player){
			isInside = false;
		}
	}

	public void Update(){
		if(isInside){
            //Restore the stamina continuosly
			playerStamina.RestoreStamina();
		}
	}
}
