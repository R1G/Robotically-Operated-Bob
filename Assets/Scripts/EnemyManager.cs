using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;
	public int spawnCount;
	public int spawnLimit;
	public int killCount;

	void Awake() {
		spawnCount = 0;
		killCount = 0;

	}

	void Start() {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {
		if (killCount >= spawnCount) {
			Application.Quit ();
		}
		if (spawnCount < spawnLimit) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			enemy.tag = "Enemy";
			spawnCount++;
		} else {
			return;
		}
	}
}
