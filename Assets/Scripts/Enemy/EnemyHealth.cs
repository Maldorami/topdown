using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Bullet") {
			health -= 10;
		}
	}

	void Update(){
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
