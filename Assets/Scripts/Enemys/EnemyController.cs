using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	PlayerHealth playerHealth;

	void Awake(){
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.FindWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	void Update(){
		if(playerHealth.currentHealth > 0){
			nav.SetDestination(player.position);
			
		}
	}
}
