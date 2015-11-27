using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    //Public references
	public Transform player;
	public NavMeshAgent nav;
	public PlayerHealth playerHealth;

    public void Awake(){
        //Initialize components
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.FindWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
	}

    public void Update(){
        //If the player is alive...
		if(playerHealth.currentHealth > 0){
            //...Pathfind him
			nav.SetDestination(player.position);
		}
	}
}
