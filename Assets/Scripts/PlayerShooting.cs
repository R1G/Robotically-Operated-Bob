using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;
	public float effectTime = 0.1f;
	ParticleSystem attackEffects;
	public bool attackHeld;
	public Animator anim;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;

	void Awake() {
		anim = GetComponentInParent<Animator> ();
		attackEffects = GetComponent<ParticleSystem> ();
	}

	void Start() {
		attackEffects.Stop ();
		attackHeld = false;
	}

	void Update() {
		if (timer >= effectTime) {
			attackEffects.Stop ();
		}
			Shoot ();
		timer += Time.deltaTime;
	}

	void Shoot() {
		if (Input.GetButton ("Fire1")) {
			timer = 0f;
			if (attackHeld == false) {
				float animChoice = Random.Range (0, 2);
				if (animChoice == 0) {
					anim.SetBool ("stabHold",true);
					attackHeld = true;
				} else {
					anim.SetBool ("swingHold",true);
					attackHeld = true;
				}
			}
		}

		if (Input.GetButtonUp ("Fire1") && attackHeld == true) {
			attackHeld = false;
			//animation and visual
			anim.SetBool ("stabHold", false);
			anim.SetBool ("swingHold", false);
			attackEffects.Emit (10);

			//raycast and damage
			shootRay.origin = transform.position;
			shootRay.direction = transform.forward;
			if (Physics.Raycast (shootRay, out shootHit, range)) {
				if (shootHit.collider.gameObject.tag == "Enemy") {
					EnemyHealth enemyHealth = shootHit.collider.gameObject.GetComponent<EnemyHealth> ();
					enemyHealth.TakeDamage (damagePerShot);
				}
			}
		}
	}

}
