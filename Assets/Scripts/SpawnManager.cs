using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	private static SpawnManager instance;
    
	public List<GameObject> spawnList;
	private float timer = 0;
	public float spawnDelay = 2;

	bool stop = false;

	void Start(){

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

		spawnList = new List<GameObject> ();
		GameObject[] tmp = GameObject.FindGameObjectsWithTag ("Spawn");

		foreach (GameObject ob in tmp) {
			spawnList.Add (ob);
		}
	}

	void Update(){
		timer += Time.deltaTime;



		if(timer > spawnDelay){
			foreach (GameObject sp in spawnList) {
				Spawn tmp = sp.GetComponent<Spawn> ();
				if (!stop) {
					tmp.SpawnEnemy ();
					stop = true;
				}
			}
			timer = 0;
		}
	}
}
