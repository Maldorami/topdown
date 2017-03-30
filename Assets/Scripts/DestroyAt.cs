using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAt : MonoBehaviour {

	public float timer = 5;
	float tmp;
	
	// Update is called once per frame
	void Update () {
		tmp += Time.deltaTime;
		if (tmp > timer) {
			Destroy (gameObject);
		}
	}
}
