using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyChase : MonoBehaviour {

	Transform Player;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent>();
	}
		
	void Update(){
		nav.SetDestination (Player.position);
	}
}
