using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	public float speed = 15;

	Rigidbody rg;
	Rigidbody playerRG;

	Vector3 velocity;

	void Start(){
		rg = GetComponent<Rigidbody> ();
		playerRG = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
		velocity = transform.forward * speed + playerRG.velocity;
	}
	// Update is called once per frame
	void Update () {
		rg.velocity = (velocity);
	}
}
