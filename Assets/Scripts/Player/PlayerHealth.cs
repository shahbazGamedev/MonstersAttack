using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    //Public ints
	public int startingHealth;
	public int currentHealth;

    //Public references
	public Slider healthSlider;
	public Image flashImage;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	public PlayerController playerController;
	public PlayerShooting playerShooting;

    //Private floats
	private float flashDuration = 2f;

    //Private bools
	private bool damaged;
	private bool isDead;

	void Awake(){
		currentHealth = startingHealth;

		playerController = GetComponent<PlayerController>();
		playerShooting = GetComponent<PlayerShooting>();

		damaged = false;

		healthSlider = GameObject.FindWithTag("HealthSliderHUD").GetComponent<Slider>();

        flashImage = GameObject.Find("DamageSplash").GetComponent<Image>();

        flashImage.enabled = false;


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
