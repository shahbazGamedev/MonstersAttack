using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	int playerHealth, playerStamina, playerReStamina, playerDamage;  // PlayerStats
	float playerAttackSpeed;

	void Awake(){
		playerDamage = PlayerPrefs.GetInt("Damage"); // Use x10 x25 x50 x100 x500 Values
		playerHealth = PlayerPrefs.GetInt("Health"); // Use x10 x100 x1.000 x10.000 Values
		playerStamina = PlayerPrefs.GetInt("Stamina"); // Use x1.2 x1.4 x1.6 x1.8 x2.2 Values
		playerReStamina = PlayerPrefs.GetInt("ReStamina"); // Use x1.2 x1.4 x1.6 x1.8 x2.2 Values
		playerAttackSpeed = PlayerPrefs.GetFloat("AttackSpeed"); // Use x1.2 x1.4 x1.6 x1.8 x2.2 Values
	}

	void Update(){
		
	}
	
}
