using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeHealth : MonoBehaviour {

	PlayerHealth playerHealth;
	bool healthUp;
	GameObject player;

	Slider healthSlider;

	void Awake(){
		playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		player = GameObject.FindWithTag("Player");
		healthSlider = GameObject.FindWithTag("HUDSlider").GetComponent<Slider>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			healthUp = true;
		}
	}



	void Update(){
		if(healthUp){
			playerHealth.currentHealth = 100;
			healthSlider.value = playerHealth.currentHealth;
			healthUp = false;
			Destroy(this.gameObject);
		}
	}
}
