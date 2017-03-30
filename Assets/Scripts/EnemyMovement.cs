using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;

	GameObject player;
	Rigidbody rg;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rg = GetComponent<Rigidbody> ();
	}

	void Update () {
		transform.LookAt (player.transform.position);
		rg.velocity = (transform.forward * speed);
	}
}
