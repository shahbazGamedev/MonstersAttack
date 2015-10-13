using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.2f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;

	float timer;
	bool playerInRange;

	void Awake(){
		player = GameObject.FindWithTag("Player");

		playerHealth = player.GetComponent<PlayerHealth>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			playerInRange = true;
		}
	}	

	void OnTriggerExit(Collider other){
		if(other.gameObject == player){
			playerInRange = false;
		}
	}

	void Update(){
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange){
			Attack();
		}
	}

	void Attack(){
		timer = 0f;

		playerHealth.TakeDamage(attackDamage);
	}


}
