using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void SpawnEnemy(){
		GameObject tmp = EnemyBuilder.Instance.Build (EnemyBuilder.EnemyType.zombie);
		tmp.transform.position = gameObject.transform.position;
	}

}
