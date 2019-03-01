using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerControls : MonoBehaviour {

	public float Speed;
	public float Sesetivity;
	public float PowerJump;

	public Rigidbody RB;
	bool onGround;

	void Start(){
		
	}



	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * Speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.forward * -Speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * Speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.left * -Speed * Time.deltaTime);
		}


		float rotX = Input.GetAxis ("Mouse X") *Sesetivity;
		transform.Rotate(0,rotX,0);

		if (onGround == true) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				RB.velocity = new Vector3 (0, PowerJump, 0);
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == ("Land")){
			onGround = true;
		}
	} 
	void OnCollisionExit(Collision other){
		if (other.gameObject.tag == ("Land")) {
			onGround = false;
		}
	}
}
