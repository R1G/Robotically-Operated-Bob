using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	Animator anim;

	void Awake() {
		anim = GetComponentInChildren<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update() {
		nav.SetDestination (player.position);
		anim.SetFloat ("speed", nav.speed);
	}

}
