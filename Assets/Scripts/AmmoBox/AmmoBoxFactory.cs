using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxFactory : MonoBehaviour {

	public static AmmoBoxFactory instance;

	void Awake(){
		if (!instance) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

	}

	public GameObject Create(){
		GameObject go = Resources.Load ("ammobox", typeof(GameObject)) as GameObject;
		return Instantiate (go);
	}

}
