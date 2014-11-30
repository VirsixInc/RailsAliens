using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float upDownRange = 60.0f;
	public float verticalRotation = 0.0f;

	// Update is called once per frame
	void Update () {

//		//rotation
//		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity; //retrieve lateral mouse movement
//		transform.Rotate (0, rotLeftRight, 0);
//
//		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity; //retrieve vertical mouse movement
//		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange); //do not let vertical movement beyond range
//
//		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0); //move the camera (instead of controller) vertically 

		//movement

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed; //request speed from input which is already mapped to asdw
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed; //request speed from input which is already mapped to asdw

		Vector3 speed = new Vector3 (sideSpeed, 0, forwardSpeed); //create a direction vector from forwardSpeed

		speed = transform.rotation * speed; //changes the vector direction of speed to match rotation direction

		CharacterController cc = GetComponent<CharacterController> (); //find character controller

		cc.SimpleMove (speed); //move controller
	
	}



}
