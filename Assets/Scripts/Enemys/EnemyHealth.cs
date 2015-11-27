using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    //Public bools
    public bool isDead;

    //Public ints
    public int startingHealth=100;
	public int currentHealth;

    public void Awake(){
        //Set up the current health
		currentHealth = startingHealth;
	}

    public void Update(){
		if(currentHealth<=0){
			Death();
		}
	}

    //Function to lose health
	public void TakeDamage(int amount, Vector3 hitPoint){
		currentHealth = currentHealth - amount;		
	}

    //Function to die (need to apply a transfrom to hide it into the ground)
    public void Death(){
		Destroy(this.gameObject);
	}
}
