using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour {

	private static EnemyBuilder instance;

	public static EnemyBuilder Instance
	{
		get 
		{
			if (instance == null)
			{
				GameObject go = new GameObject ("EnemyBuilder");
				instance = go.AddComponent<EnemyBuilder>();
			}
			return instance;
		}
	}

	public enum EnemyType{
		zombie,
		mommy,
		spider
	}

	public GameObject Build (EnemyType type){

		GameObject go = EnemyFactory.Instance.Create (type);

		switch (type) {
		case (EnemyType.zombie):{
				Rigidbody rg = go.AddComponent<Rigidbody> ();


				EnemyMovement enmMov = go.AddComponent<EnemyMovement>();
				enmMov.speed = 5;

				return go;
			}
		case (EnemyType.mommy):{
				go.AddComponent<EnemyMovement>();
				return go;
			}
		case (EnemyType.spider):{
				go.AddComponent<EnemyMovement>();
				return go;
			}
		}

		return null;
	}
}
