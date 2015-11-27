using UnityEngine;
using System.Collections;

public class RedCube : MonoBehaviour {

	//Red cube is a healing cube acting only in the radius of the children collider

    //Public bools
	public 	bool isInside;
	
    //Private references
	private GameObject player;
	private PlayerHealth playerHealth;
	private Renderer rend;

	public void Awake(){
        //Initialize components
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		rend = GameObject.FindWithTag("RendPlayer").GetComponent<Renderer>();
	}

	public void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
		isInside = true;
		}
	}

	public void OnTriggerExit(Collider other){
		if(other.gameObject == player){
		isInside = false;
		}
	}

    public void Update(){
		if(isInside){
			int amount = 1;
            //If the player have health to restore
            if (playerHealth.currentHealth<100){
                //Perform the healing		
                playerHealth.currentHealth += amount;
			}
		}
	}
}
