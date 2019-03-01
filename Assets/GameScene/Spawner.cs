using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


	PlayerHealth playerHealth;
	GameObject player;

	public GameObject enemy;
	public float spawnTime =3f;
	public Transform[] SpawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void Spawn(){
		if (playerHealth.CurrentHealth <= 0f) {
			return;
		}

		int spawnPointIndex = Random.Range (0, SpawnPoints.Length);

		Instantiate (enemy, SpawnPoints [spawnPointIndex].position, SpawnPoints [spawnPointIndex].rotation);
	}
}
