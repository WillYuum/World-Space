using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float StartingHealth = 100;
	public float CurrentHealth;
	public float AmountHealthRegained;


	PlayerHealth _playerHealth;

	// Use this for initialization
	void Start () {
		CurrentHealth = StartingHealth;
		_playerHealth = GetComponent<PlayerHealth>();
	}

	public void TakeDamage(float amount){

		CurrentHealth -= amount;

		if (CurrentHealth <= 0) {
			Death ();
		}
	}

	void Death(){
		Destroy (gameObject);
		_playerHealth.HealthRegainer (AmountHealthRegained);
	}

	// Update is called once per frame
	void Update () {

	}
}
