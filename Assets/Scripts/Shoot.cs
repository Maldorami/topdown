﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public float speed = 1;
	float timer = 0;

	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1"))
		
		if (timer > speed) {
			Instantiate (bullet, transform.position, transform.rotation);
			timer = 0;
		}

	}
}
