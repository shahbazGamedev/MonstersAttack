using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {

	public GameObject[] cubesType;
	public float spawnTime = 10f;
	public Transform[] spawnPoints;


	void Start(){
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn(){

		int cubesTypeIndex = Random.Range(0, cubesType.Length);
		int spawnPointsIndex = Random.Range (0, spawnPoints.Length);

		Instantiate(cubesType[cubesTypeIndex], spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
	}
}
