using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 1f;
	public float Damage;
	public float doubleDamage;

	float timer;

	GameObject Player;
	GameObject Sun;
	GameObject Eye;

	bool PlayerInRange;
	bool DayTime;

	PlayerHealth _playerHealth;
	EnemyHealth _enemyHealth;

	public Animator EyeAnim;


	void Awake(){
		Player = GameObject.FindGameObjectWithTag ("Player");
		Sun = GameObject.FindGameObjectWithTag ("Sun");
		_playerHealth = Player.GetComponent<PlayerHealth> ();
		_enemyHealth = GetComponent<EnemyHealth> ();
		Eye = GameObject.FindGameObjectWithTag ("EyeBall");
		EyeAnim = Eye.GetComponent<Animator> ();
	}

	 void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == ("Player")){
			PlayerInRange = true;
			Debug.Log ("Ouch!");

		}
	}

	  void OnCollisionExit(Collision other){
		if (other.gameObject.tag == ("Player")) {
			PlayerInRange = false;
			Debug.Log ("He's Away");

		}
	}

	void Update(){
		timer += Time.deltaTime;


		if (timer >= timeBetweenAttacks && PlayerInRange && _enemyHealth.CurrentHealth > 0) {
			Attack ();
		}
	

		if (Sun.transform.position.y < 0) {
			DayTime = false;
		}
		if (Sun.transform.position.y > 0) {
			DayTime = true;
		}
	}

	void FixedUpdate(){
		if (PlayerInRange) {
			EyeAnim.Play ("EyeBall_Animation");
		}
	}

		
	void Attack(){
		timer = 0f;

		if (_playerHealth.CurrentHealth > 0) {
			_playerHealth.TakeDamage (Damage);
		}

		if(_playerHealth.CurrentHealth > 0 && !DayTime){
			_playerHealth.TakeDamage (Damage * doubleDamage);
			Debug.Log ("Damage is doubled");
		}
	}
}
