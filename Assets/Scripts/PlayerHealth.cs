using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	Animator anim;

	bool isDead;
	bool damaged;

	PlayerMovement playerMovement;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement> ();
		currentHealth = startingHealth;
		anim = GetComponentInChildren<Animator> ();
	}
	/*
	void Update() {
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	*/

	public void TakeDamage(int amount) {
		damaged = true;
		currentHealth -= amount;

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	void Death() {
		isDead = true;
		playerMovement.enabled = false;
		anim.SetBool ("dead", true);
	}

}
