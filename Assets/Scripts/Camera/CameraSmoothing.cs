using UnityEngine;
using System.Collections;

public class CameraSmoothing : MonoBehaviour {

	float smoothamount = 5f;
	public Transform target;

	Vector3 offset;

	void Start(){
		offset = transform.position - target.position;
	}

	void FixedUpdate(){
		Vector3 targetCameraPosition = target.position + offset;

		transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothamount*Time.deltaTime);
	}
}
