using UnityEngine;
using System.Collections;

public class CameraSmoothing : MonoBehaviour {

    //Private floats
	private float smoothamount = 5f;

    //Private references
	public Transform target;

    //Private references
	private Vector3 offset;

	void Start(){
        //Set up the offset depeding on the difference between both
		offset = transform.position - target.position;
	}

	void FixedUpdate(){
        //Calculate the camera position
		Vector3 targetCameraPosition = target.position + offset;

        //Transform the camera position
		transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothamount*Time.deltaTime);
	}
}
