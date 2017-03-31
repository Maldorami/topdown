using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	private static SpawnManager instance;

	public static SpawnManager Instance
	{
		get 
		{
			if (instance == null)
			{
				GameObject go = new GameObject ("SpawnManager");
				instance = go.AddComponent<SpawnManager>();
			}
			return instance;
		}
	}

	public List<GameObject> spawnList;
	private float timer = 0;
	public float spawnDelay = 2;

	void Start(){
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
				tmp.SpawnEnemy ();
			}

			timer = 0;
		}
	}
}
