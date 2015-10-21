using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public Slider healthSlider;
	public Image flashImage;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	public PlayerController playerController;
	public PlayerShooting playerShooting;

	private float flashDuration = 2f;
	private bool damaged;
	private bool isDead;

	void Awake(){
		currentHealth = startingHealth;

		playerController = GetComponent<PlayerController>();
		playerShooting = GetComponent<PlayerShooting>();

		damaged = false;

		healthSlider = GameObject.FindWithTag("HealthSliderHUD").GetComponent<Slider>();


	}

	void Update(){
		if(damaged){
			flashImage.color = flashColor;
		}
		else{
			flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashDuration * Time.deltaTime);
		}

		damaged=false;

		healthSlider.value = currentHealth;
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;

		damaged = true;

	}
}
