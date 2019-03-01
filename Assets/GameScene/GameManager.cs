using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public float RestartTime;

	bool GameEnded = false;

	public void EndGame(){
		if (GameEnded == false) {
			GameEnded = true;
			Debug.Log ("GameOver");
			Invoke ("Restart", RestartTime);
		}
	}

	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
