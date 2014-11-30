using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;

	void Update () {

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		Vector3 speed = new Vector3 (sideSpeed, 0, forwardSpeed); //create a direction vector from forwardSpeed

		speed = transform.rotation * speed; //changes the vector direction of speed to match rotation direction

		CharacterController cc = GetComponent<CharacterController> (); //find character controller

		cc.SimpleMove (speed); //move controller
	
	}



}
