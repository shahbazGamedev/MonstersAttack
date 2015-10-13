using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

	Canvas canvas;

	void Start(){
		canvas = GetComponent<Canvas>();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			canvas.enabled = !canvas.enabled;
			Pause();
		}
	}

	public void Pause(){
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
}
