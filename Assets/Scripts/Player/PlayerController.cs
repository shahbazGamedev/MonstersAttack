using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float speed=100f;
	Vector3 movementDirection;
	Rigidbody playerRigidBody, parentRigidBody;

	int floorMask;
	float cameraRayLenght = 1000f;
	Vector3 playerToMouse;
	Animator anim;

	PlayerStamina playerStamina;

	private void Awake(){

		playerRigidBody = GetComponent<Rigidbody>();
		parentRigidBody = GetComponentInParent<Rigidbody>();

		floorMask = LayerMask.GetMask("Ground");

		anim = GetComponent<Animator>();

		playerStamina = GetComponent<PlayerStamina>();

	}

	private void FixedUpdate(){
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		bool r = Input.GetButton("Fire3");

		Move(h,v,r);
		Turning();
		Anime(h,v);
	}

	void Move(float h, float v, bool r){
		if(r && playerStamina.currentStamina > 0){
			speed = 100f;
			anim.SetFloat("Speed", 1.5f);
			playerStamina.ConsumingStamina(1);
		}else{
			speed = 50f;
			anim.SetFloat("Speed", 1f);
		}
		movementDirection.Set(h,0f,v);
		movementDirection = movementDirection.normalized * speed * Time.deltaTime;
		playerRigidBody.MovePosition (movementDirection + transform.position);
	}

	void Turning(){
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit groundHit;

		if(Physics.Raycast(cameraRay, out groundHit, cameraRayLenght, floorMask)){
			playerToMouse = groundHit.point - transform.position;
			playerToMouse.y=0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			parentRigidBody.MoveRotation(newRotation);
		}
	}

	void Anime(float h, float v){

			//Controlling axes depending on player look
		if(playerToMouse.x >= 0 && playerToMouse.z >= 0){  
			anim.SetFloat("VAxis", CrossPlatformInputManager.GetAxis("Vertical"));
			anim.SetFloat("HAxis", CrossPlatformInputManager.GetAxis("Horizontal"));
		}

		if(playerToMouse.x >= 0 && playerToMouse.z < 0){  
			anim.SetFloat("VAxis", CrossPlatformInputManager.GetAxis("Horizontal"));
			anim.SetFloat("HAxis", CrossPlatformInputManager.GetAxis("Vertical")*(-1));
		}

		if(playerToMouse.x < 0 && playerToMouse.z < 0){  
			anim.SetFloat("VAxis", CrossPlatformInputManager.GetAxis("Vertical") * (-1));
			anim.SetFloat("HAxis", CrossPlatformInputManager.GetAxis("Horizontal") * (-1));
		}

		if(playerToMouse.x < 0 && playerToMouse.z >= 0){  
			anim.SetFloat("VAxis", CrossPlatformInputManager.GetAxis("Horizontal") * (-1));
			anim.SetFloat("HAxis", CrossPlatformInputManager.GetAxis("Vertical"));
		}



	}
}
