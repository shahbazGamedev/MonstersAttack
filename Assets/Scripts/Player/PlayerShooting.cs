using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damage = 50;
	public float attackSpeed=0.15f;
	public float range = 1000f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;

	//ParticleSystem gunParticles;
	LineRenderer gunLine;
	Light gunLight;
	float effectDisplayTime = 0.2f;

	PlayerStamina playerStamina;


	void Awake(){
		shootableMask = LayerMask.GetMask("Shootable");

		//damage = PlayerPrefs.GetInt("Damage");
		damage = 20;

		//gunParticles = GetComponent<ParticleSystem>();
		gunLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();

		playerStamina = GameObject.FindWithTag("Player").GetComponent<PlayerStamina>();
	}

	void Update(){
		timer += Time.deltaTime;

		if(Input.GetButton("Fire1") && timer>=attackSpeed && playerStamina.currentStamina > 0){

			Shoot();
		}

		if(timer >= attackSpeed * effectDisplayTime){

			DissableEffects();
		}
	}

	void DissableEffects(){

		gunLine.enabled = false;
		gunLight.enabled = false;

	}

	void Shoot(){
		timer = 0f;

		gunLight.enabled = true;

		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		//gunParticles.Stop();
		//gunParticles.Play();


		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		playerStamina.ConsumingStamina(playerStamina.consumingValue);

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)){
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();			
			
			if(enemyHealth != null){
				enemyHealth.TakeDamage(damage, shootHit.point);
			}

			gunLine.SetPosition(1, shootHit.point);
			
		}
		else{

			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
