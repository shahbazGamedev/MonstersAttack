using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsPoints : MonoBehaviour {
	string playerSkill;
	int playerSkillValue;
	int sliderValue;
	private float damageSlider, healthSlider, staminaSlider, reStaminaSlider, attackSpeedSlider;
	public int skillPoints;

	void Start(){
		damageSlider = GameObject.Find("Slider_Damage").GetComponent<Slider>().value;
		healthSlider = GameObject.Find("Slider_Health").GetComponent<Slider>().value;
		staminaSlider = GameObject.Find("Slider_Stamina").GetComponent<Slider>().value;
		reStaminaSlider = GameObject.Find("Slider_ReStamina").GetComponent<Slider>().value;
		attackSpeedSlider = GameObject.Find("Slider_AttackSpeed").GetComponent<Slider>().value;
		Debug.Log("Value loaded");
		HaveSkillPoints();
		skillPoints = 10;
	}

	void ReloadComponents(){
		damageSlider = GameObject.Find("Slider_Damage").GetComponent<Slider>().value;
		healthSlider = GameObject.Find("Slider_Health").GetComponent<Slider>().value;
		staminaSlider = GameObject.Find("Slider_Stamina").GetComponent<Slider>().value;
		reStaminaSlider = GameObject.Find("Slider_ReStamina").GetComponent<Slider>().value;
		attackSpeedSlider = GameObject.Find("Slider_AttackSpeed").GetComponent<Slider>().value;
		Debug.Log("Value reloaded");
	}

	public void SetString(string skillName){
		playerSkill = skillName;
	}

	
	public void SetSkill(){
		ReloadComponents();
		switch(playerSkill){
			case "Damage":
			int damageSliderint = (int) damageSlider;
					switch (damageSliderint){
					case 0:
					playerSkillValue = 10;
					break;
					case 1:
					playerSkillValue = 10*10;
					break;
					case 2:
					playerSkillValue = 10*25;
					break;
					case 3:
					playerSkillValue = 10*50;
					break;
					case 4:
					playerSkillValue = 10*100;
					break;
					case 5:
					playerSkillValue = 10*500;
					break;
					default:
					Debug.Log("ERROR. Setting up damage.");
					break;
				}

				
			break;
			case "Health":
			int healthSliderint = (int) healthSlider;
					switch (healthSliderint){
					case 0:
					playerSkillValue = 100;
					break;
					case 1:
					playerSkillValue = 100*10;
					break;
					case 2:
					playerSkillValue = 100*100;
					break;
					case 3:
					playerSkillValue = 100*250;
					break;
					case 4:
					playerSkillValue = 100*500;
					break;
					case 5:
					playerSkillValue = 100*1000;
					break;
					default:
					
					break;
				}
			break;
			case "Stamina":
			int staminaSliderint = (int) staminaSlider;
					switch (staminaSliderint){
					case 0:
					playerSkillValue = 100;
					break;
					case 1:
					playerSkillValue = 100*2;
					break;
					case 2:
					playerSkillValue = 100*4;
					break;
					case 3:
					playerSkillValue = 100*6;
					break;
					case 4:
					playerSkillValue = 100*8;
					break;
					case 5:
					playerSkillValue = 100*12;
					break;
					default:
					Debug.Log("ERROR. Setting up stamina.");
					break;
				}
			break;
			case "ReStamina":
			int reStaminaSliderint = (int) reStaminaSlider;
					switch (reStaminaSliderint){
					case 0:
					playerSkillValue = 100;
					break;
					case 1:
					playerSkillValue = 100*12;
					break;
					case 2:
					playerSkillValue = 100*14;
					break;
					case 3:
					playerSkillValue = 100*16;
					break;
					case 4:
					playerSkillValue = 100*18;
					break;
					case 5:
					playerSkillValue = 100*22;
					break;
					default:
					Debug.Log("ERROR. Setting up Restamina.");
					break;
				}
			break;
			case "AttackSpeed":
			int attackSpeedSliderint = (int) attackSpeedSlider;
					switch (attackSpeedSliderint){
					case 0:
					playerSkillValue = 100;
					break;
					case 1:
					playerSkillValue = 100*12;
					break;
					case 2:
					playerSkillValue = 100*14;
					break;
					case 3:
					playerSkillValue = 100*16;
					break;
					case 4:
					playerSkillValue = 100*18;
					break;
					case 5:
					playerSkillValue = 100*22;
					break;
					default:
					Debug.Log("ERROR. Setting up attackspeed.");
					break;
				}
			break;
			default:
			Debug.Log("ERROR, Setting up the skills.");
			break;

		}
		PlayerPrefs.SetInt(playerSkill, playerSkillValue);
		skillPoints = skillPoints - 1;
	}

	void HaveSkillPoints(){
		if(skillPoints<=0){
			foreach(GameObject Sliders in GameObject.FindGameObjectsWithTag("Slider")){
				Sliders.GetComponent<Slider>().enabled = false;
			}
		}else{
			foreach(GameObject Sliders in GameObject.FindGameObjectsWithTag("Slider")){
				Sliders.GetComponent<Slider>().enabled = true;
			}
		}
	}

	void Update(){
		HaveSkillPoints();
	}



}
