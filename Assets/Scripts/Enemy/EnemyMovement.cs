using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	public Animator anim;

	float AttackTimer;
	float tmp = 0;
	bool attack = true;
	bool move = true;
	bool distanceToDamage = false;

	EnemyDamage ed;


	GameObject player;
	Rigidbody rg;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rg = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		ed = GetComponent<EnemyDamage> ();
	}

	void Update () {
		Vector3 look = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

		if (Vector3.Distance (transform.position, look) < 2) {
			distanceToDamage = true;
		} else {
			distanceToDamage = false;
		}

		if (!distanceToDamage && move) {			
			transform.LookAt (look);
			rg.velocity = (transform.forward * speed);
		} else {
			tmp += Time.deltaTime;

			if (attack) {
				anim.SetTrigger ("Attacking");
				attack = false;
				move = false;
				rg.velocity = Vector3.zero;
			} else {
				if (distanceToDamage && tmp > .25f) {
					Debug.Log("<color=yellow>zombie attack!</color>");
					ed.DoDamageToPlayer ();
					tmp = 0;
				}
			}

			AttackTimer += Time.deltaTime;
			if (AttackTimer > .5f) {
				move = true;
				attack = true;
				AttackTimer = 0;
				tmp = 0;
			}
		}

	}
}
