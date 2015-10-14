using UnityEngine;
using System.Collections;

public class BlueCube : MonoBehaviour {

	// Blue cube increase the attack damage and change shooting color when the player is inside the children collider

	public bool isInside;
	GameObject player;
	GameObject rifleTip;
	LineRenderer gunLine;
	Light gunLight;
	public Color c1 = Color.red;
	public Color c2 = Color.red;
	public Color c3 = Color.yellow;
	public Color c4 = Color.yellow;
	PlayerShooting playerShooting;
	PlayerStamina playerStamina;
	Renderer rend;
	

	void Awake(){
		player = GameObject.FindWithTag("Player");
		rifleTip = GameObject.Find("RifleTip");
		gunLine = rifleTip.GetComponent<LineRenderer>();
		gunLight = rifleTip.GetComponent<Light>();
		playerShooting = rifleTip.GetComponent<PlayerShooting>();
		playerStamina = player.GetComponent<PlayerStamina>();
		rend = GameObject.FindWithTag("RendPlayer").GetComponent<Renderer>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			isInside = true;
			playerShooting.damage = playerShooting.damage * 2;
			playerStamina.consumingValue = 10;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject == player){
			isInside = false;
			playerShooting.damage = playerShooting.damage / 2;
			playerStamina.consumingValue = 5;
		}
	}

	void Update(){
		if(isInside){
			gunLine.SetColors(c1, c2);
			gunLine.SetWidth (1f, 1f);
			gunLight.color = Color.red;
			//Debug.Log(playerShooting.damage);
		}
		else{
			gunLine.SetColors(c3, c4);
			gunLine.SetWidth(0.5f, 0.5f);
			gunLight.color = Color.yellow;
			//Debug.Log(playerShooting.damage);
		}
	}
}
