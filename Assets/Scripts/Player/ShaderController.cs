using UnityEngine;
using System.Collections;

public class ShaderController : MonoBehaviour {

	// This script control the emissions of the shader depending on which cubes are affecting the player

	BlueCube blueCube;
	RedCube redCube;
	GreenCube greenCube;
	Renderer rend;
	Light neckLight;
	
	void Awake(){
		rend = GetComponent<Renderer>();
		blueCube = GameObject.FindWithTag("BlueCube").GetComponent<BlueCube>();
		redCube = GameObject.Find("HealingTrigger").GetComponent<RedCube>();
		greenCube = GameObject.Find("StaminaTrigger").GetComponent<GreenCube>();
		neckLight = GameObject.FindWithTag("NeckLight").GetComponent<Light>();
	}

	void Update(){
		if(!blueCube.isInside == true && !redCube.isInside && !greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.white);
			neckLight.color = Color.white;
		}
		if(blueCube.isInside == true && !redCube.isInside && !greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.blue);
			neckLight.color = Color.blue;
		}
		if(!blueCube.isInside == true && redCube.isInside && !greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.red);
			neckLight.color = Color.red;
		}
		if(!blueCube.isInside == true && !redCube.isInside && greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.green);
			neckLight.color = Color.green;
		}
		if(blueCube.isInside == true && redCube.isInside && !greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.magenta);
			neckLight.color = Color.magenta;
		}
		if(blueCube.isInside == true && redCube.isInside && !greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.magenta);
			neckLight.color = Color.magenta;
		}
		if(blueCube.isInside == true && !redCube.isInside && greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.cyan);
			neckLight.color = Color.cyan;
		}
		if(!blueCube.isInside == true && redCube.isInside && greenCube.isInside){
			rend.material.SetColor("_EmissionColor", new Color(1F, 0.4F, 0F, 0F));
			neckLight.color = new Color(1F, 0.4F, 0F, 0F);

		}
		if(blueCube.isInside == true && redCube.isInside && greenCube.isInside){
			rend.material.SetColor("_EmissionColor", Color.yellow);
			neckLight.color = Color.yellow;
		}
	}	
}
