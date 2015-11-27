using UnityEngine;
using System.Collections;

public class BlueCube : MonoBehaviour {

	//Blue cube increase the attack damage and change shooting color when the player is inside the children collider

    //Public bools
	public bool isInside;

    //Public references
	public Color c1 = Color.red;
	public Color c2 = Color.red;
	public Color c3 = Color.yellow;
	public Color c4 = Color.yellow;
	
    //Private references
	private GameObject player;
	private GameObject rifleTip;
	private LineRenderer gunLine;
	private Light gunLight;
	private PlayerShooting playerShooting;
	private PlayerStamina playerStamina;
	private Renderer rend;
	

	public void Awake(){
        //Initialize components
		player = GameObject.FindWithTag("Player");
		rifleTip = GameObject.Find("RifleTip");
		gunLine = rifleTip.GetComponent<LineRenderer>();
		gunLight = rifleTip.GetComponent<Light>();
		playerShooting = rifleTip.GetComponent<PlayerShooting>();
		playerStamina = player.GetComponent<PlayerStamina>();
		rend = GameObject.FindWithTag("RendPlayer").GetComponent<Renderer>();
	}

	public void OnTriggerEnter(Collider other){
        //If the player enter inside the range...
		if(other.gameObject == player){
            //Is inside true ofc...
			isInside = true;
            //Increase the damage x2
			playerShooting.damage = playerShooting.damage * 2;
            //Increase the stamina consuming value
			playerStamina.consumingValue = 10;
		}
	}

	public void OnTriggerExit(Collider other){
        //If the player exit the range
		if(other.gameObject == player){
            //Is inside false
			isInside = false;
            //Decrease the damage
			playerShooting.damage = playerShooting.damage / 2;
            //Decrease the stamina consuming value
			playerStamina.consumingValue = 5;
		}
	}

	public void Update(){
        //Change the colors when is inside the cube range
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
