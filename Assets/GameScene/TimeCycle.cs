using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour {

	public GameObject Sun;

	public float TimeSpeed;
	
	// Update is called once per frame
	void Update () {

		Sun.transform.RotateAround (Vector3.zero, Vector3.left,TimeSpeed * Time.deltaTime);
		Sun.transform.LookAt (Vector3.zero);
	}
}
