using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

	public float StartingHealth = 100;
	public float CurrentHealth;

	private Image HealthBar;


	public GameObject firstBloodCap;
	public GameObject secondBloodCap;

	public Image damageImage;
	public float flashSpeed;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	public Color Screen = new Color();
	bool Damaged;


	// Use this for initialization
	void Start () {
		CurrentHealth = StartingHealth;

		HealthBar = transform.Find ("HUDCanvas").Find ("BackGround").Find ("HealthBar").GetComponent<Image> ();
	}

	public void TakeDamage(float amount){

		Damaged = true;
		
		CurrentHealth -= amount;

		HealthBar.fillAmount = CurrentHealth / StartingHealth;


		if (CurrentHealth <= 0) {
			Death ();
		}
	}



	public void Death(){
		Destroy (gameObject);
		FindObjectOfType<GameManager> ().EndGame ();
	}

	public void HealthRegainer(float amount){

		if (CurrentHealth < 100) {
			amount += CurrentHealth;
		}
	}
		
	// Update is called once per frame
	void Update () {

		if (Damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed *  Time.deltaTime);
		}

		Damaged = false;


		if (CurrentHealth <= 35) {
			damageImage.color = Screen;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed *  Time.deltaTime);
		}


		if (CurrentHealth <= 75) {
			ShowBloodCap (firstBloodCap);
			if (CurrentHealth <= 55) {
				ShowBloodCap (secondBloodCap);
			}
		} else {
			UnshowBloodCap ();
		}
	}


	void ShowBloodCap(GameObject other){
		other.SetActive (true);
	}

	void UnshowBloodCap(){
		firstBloodCap.SetActive (false);
		secondBloodCap.SetActive (false);
	}
}
