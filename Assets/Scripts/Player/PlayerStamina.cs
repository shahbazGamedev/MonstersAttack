using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

	public int startingStamina=100;
	public int currentStamina;
	int restoringValue = 1;
	public int consumingValue = 5;
	Slider staminaSlider;

	float restoringSpeed;
	
	float timer=0f;
	bool shooting;

	void Awake(){
		staminaSlider = GameObject.FindWithTag("HUDStaminaSlider").GetComponent<Slider>();
		currentStamina = startingStamina;
	}

	void Update(){
		timer += Time.deltaTime;

		UpdateSlider();
		
		if(timer>=1.5){
			RestoreStamina();
		}
	}

	public void ConsumingStamina(int value){
		currentStamina = currentStamina-value;
		timer = 0f;
	}

	void RestoreStamina(){
		if(currentStamina<=100){
			currentStamina = currentStamina + restoringValue;
		}
	}

	void UpdateSlider(){
		staminaSlider.value = currentStamina;
	}

}
