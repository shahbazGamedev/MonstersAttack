using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {
    //Public ints
	public int startingStamina=100;
	public int currentStamina;
	public int restoringValue = 1;
	public int consumingValue = 5;

    //Public references
	public Slider staminaSlider;

    //Private floats
	private float restoringSpeed;
	private float timer=0f;

    //Private bools
	private bool shooting;

	void Awake(){
		staminaSlider = GameObject.FindWithTag("StaminaSliderHUD").GetComponent<Slider>();
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

	public void RestoreStamina(){
		if(currentStamina<=100){
			currentStamina = currentStamina + restoringValue;
		}
	}

	void UpdateSlider(){
		staminaSlider.value = currentStamina;
	}

}
