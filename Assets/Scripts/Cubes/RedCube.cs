using UnityEngine;
using System.Collections;

public class RedCube : MonoBehaviour {

	// Red cube is a healing cube acting only in the radius of the children collider

	
	GameObject player;
	bool isInside;

	void Awake(){
		player = GameObject.FindWithTag("Player");
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
			//Debug.Log("HURRA");  // Perform the healing action
		}
	}
}
