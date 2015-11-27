using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    //Public bools
    public bool playerInRange;

    //Public floats
    public float timeBetweenAttacks = 0.2f;
    public float timer;

    //Public ints
    public int attackDamage = 10;

    //Public references
	public GameObject player;
	public PlayerHealth playerHealth;

	public void Awake(){
        //Initialize components
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}

    //Check if the player is inside the trigger
    //Set up playerInRange depending on state
    public void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			playerInRange = true;
		}
	}

    public void OnTriggerExit(Collider other){
		if(other.gameObject == player){
			playerInRange = false;
		}
	}

    public void Update(){
		timer += Time.deltaTime;

        //If the player is inside...
		if(timer >= timeBetweenAttacks && playerInRange){
            //...Attack...
			Attack();
		}
	}

    public void Attack(){
		timer = 0f;
        //Take damage from the player
		playerHealth.TakeDamage(attackDamage);
	}


}
