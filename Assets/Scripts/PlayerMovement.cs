using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Vector3 playerMovement;
	public float playerSpeed = 3f;
	Rigidbody playerRigidBody;
	public Animator playerAnim;

	void Awake() {
		playerRigidBody = GetComponent<Rigidbody> ();
		playerAnim = GetComponentInChildren<Animator> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal")*playerSpeed;
		float v = Input.GetAxisRaw ("Vertical")*playerSpeed;
		Move (h, v);
		Turning ();
	}

	void Update() {
		if (Input.GetMouseButtonDown (1)) {
			Blink ();
		}
	}

	void Move(float h, float v) {
		playerMovement.Set (h, 0f, v);
		playerMovement = playerMovement.normalized * playerSpeed * Time.deltaTime;
		playerRigidBody.MovePosition (transform.position + playerMovement);
		playerAnim.SetFloat ("horizontal", h);
		playerAnim.SetFloat ("vertical", v);
	}

	void Turning() {
		Ray mouseLookRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mouseRayHit;

		if (Physics.Raycast (mouseLookRay, out mouseRayHit, 100f)) {
			Vector3 playerToMouse = mouseRayHit.point - transform.position;
			playerToMouse.y = 0;
			Quaternion newPlayerRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidBody.MoveRotation (newPlayerRotation);
		
		}

	}

	void Blink() {
		transform.Translate (Vector3.forward*5);
		playerAnim.SetTrigger ("roll");
	}
}
