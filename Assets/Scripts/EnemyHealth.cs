using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	bool isDead;
	public GameObject enemySpawnSystem;

	void Awake() {
		currentHealth = startingHealth;
		enemySpawnSystem = GameObject.FindGameObjectWithTag ("EnemySpawnSystem");
	}

	void Death() {
		isDead = true;
		Destroy (gameObject);
		//enemySpawnSystem.GetComponent<EnemyManager> ().killCount++;

	}

	public void TakeDamage(int amount) {
		if (isDead) {
			return;
		}
		currentHealth -= amount;
		if (currentHealth <= 0) {
			Death ();
		}
	}
}
