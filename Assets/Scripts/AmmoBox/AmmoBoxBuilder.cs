using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxBuilder : MonoBehaviour {
	public static AmmoBoxBuilder instance;

	void Awake(){
		if (!instance) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	public GameObject Build(){
		GameObject go = AmmoBoxFactory.instance.Create ();

		go.AddComponent <AmmoBox>();
		BoxCollider bc = go.AddComponent <BoxCollider>();
		bc.isTrigger = true;
		return go;
	}
}
