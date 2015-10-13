using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	Canvas canvas;

	void Start(){
		canvas = GetComponent<Canvas>();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			canvas.enabled = !canvas.enabled;
			Pause();
		}
		Debug.Log("pressed");
	}

	public void Pause(){
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

}
