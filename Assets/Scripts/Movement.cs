using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 500000;
	public float rotationSpeed = 50;
	Rigidbody rg;

	void Start(){
		rg = gameObject.GetComponent<Rigidbody>();
	}

	void Update () {
		if (Input.GetAxis ("Vertical") > 0) {
			rg.velocity = (gameObject.transform.forward * speed);
		}else
			if (Input.GetAxis ("Vertical") < 0) {
			rg.velocity = (-gameObject.transform.forward * speed);
		}
		else {
			rg.velocity = Vector3.zero;
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Rotate (Vector3.up * rotationSpeed);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.Rotate (-Vector3.up * rotationSpeed);
		}
	}
}