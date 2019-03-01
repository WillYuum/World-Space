using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour {


	PlayerHealth playerHealth;

	void Start(){
		playerHealth = GetComponent<PlayerHealth> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			playerHealth.TakeDamage (10);
		}
	}
}
