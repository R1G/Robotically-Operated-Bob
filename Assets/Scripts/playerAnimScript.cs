using UnityEngine;
using System.Collections;

public class playerAnimScript : MonoBehaviour {

	Animator anim;

	void Start() {
		anim = GetComponentInChildren<Animator> ();
	}

	void FixedUpdate() {
		
	}
}
