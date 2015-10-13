using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth=100;
	public int currentHealth;

	bool isDead;

	void Awake(){
		currentHealth = startingHealth;
	}

	void Update(){
		if(currentHealth<=0){
			Death();
		}
	}

	public void TakeDamage(int amount, Vector3 hitPoint){
		currentHealth = currentHealth - amount;
		Debug.Log(amount);
		
	}

	void Death(){
		Destroy(this.gameObject);
	}
}
