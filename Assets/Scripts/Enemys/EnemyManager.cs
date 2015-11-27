using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    //Public floats
    public float spawnTime = 3f;

    //Public references
    public GameObject enemy;
	public PlayerHealth playerHealth;
	public Transform[] spawnPoints;

    public void Start(){
        //Start to instantiate enemys
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    public void Spawn(){
        //If the player is dead
		if(playerHealth.currentHealth <= 0){
			return;
		}

        //Set up a random index for the spawnpoints
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Instantiate enemys on diferent spawnpoints
		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
