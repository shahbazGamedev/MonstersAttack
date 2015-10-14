using UnityEngine;
using System.Collections;

public class BlueCube : MonoBehaviour {

	// Blue cube increase the attack damage and change shooting color when the player is inside the children collider

	bool isInside;
	GameObject player;
	GameObject rifleTip;
	LineRenderer gunLine;
	public Color c1 = Color.blue;
	public Color c2 = Color.blue;
	public Color c3 = Color.yellow;
	public Color c4 = Color.yellow;
	

	void Awake(){
		player = GameObject.FindWithTag("Player");
		rifleTip = GameObject.Find("RifleTip");
		gunLine = rifleTip.GetComponent<LineRenderer>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			isInside = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject == player){
			isInside = false;
		}
	}

	void Update(){
		if(isInside){
			gunLine.SetColors(c1, c2);
			gunLine.SetWidth (1f, 1f);
		}
		else{
			gunLine.SetColors(c3, c4);
			gunLine.SetWidth(0.5f, 0.5f);
		}
	}
}
