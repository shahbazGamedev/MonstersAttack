using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    //Public floats
	public float speed=100f;

    //Public references
	public PlayerStamina playerStamina;

    //Private ints
	private int floorMask;

    //Private floats
	private float cameraRayLenght = 1000000f;

    //Private references
	private Rigidbody playerRigidBody, parentRigidBody;
	private Vector3 movementDirection;
	private Vector3 playerToMouse;
	private Animator anim;

	private void Awake(){
        //Initialize components
		playerRigidBody = GetComponent<Rigidbody>();
		parentRigidBody = GetComponentInParent<Rigidbody>();
		anim = GetComponent<Animator>();
		playerStamina = GetComponent<PlayerStamina>();

        //Get the floor mask
        floorMask = LayerMask.GetMask("Ground");

    }

	private void FixedUpdate(){
        //Get axis every frame (This must be fixed with a #if mobile input)
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		bool r = Input.GetButton("Fire3");

		Move(h,v,r);
		Turning();
		Anime(h,v);
	}

    //Function to perform the player movement
	void Move(float h, float v, bool r){
		if(r && playerStamina.currentStamina > 0){
			speed = 100f;
			anim.SetBool("Sprint", true);
			playerStamina.ConsumingStamina(1);
		}else{
			speed = 50f;
			anim.SetBool("Sprint", false);
		}
		movementDirection.Set(h,0f,v);
		movementDirection = movementDirection.normalized * speed * Time.deltaTime;
		playerRigidBody.MovePosition (movementDirection + transform.position);
	}

    //Function to perform the player turning
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

    //Function to control the animations (Must be fixed with new animations)
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
		

		/*if(h > 0 || v > 0){
			anim.SetBool("IsMoving", true);
		}else{
			anim.SetBool("IsMoving", false);
		}*/



	}
}
