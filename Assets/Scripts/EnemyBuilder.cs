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
				BoxCollider bc = go.AddComponent<BoxCollider> ();
				EnemyHealth eh = go.AddComponent<EnemyHealth> ();
				EnemyDamage ed = go.AddComponent<EnemyDamage> ();

				EnemyMovement enmMov = go.AddComponent<EnemyMovement>();
				rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
				enmMov.speed = 3;

				Vector3 bound = new Vector3 (0.1f, 0.1f, 0.1f);
				Vector3 center = new Vector3 (0, .1f, .02f);
				bc.center = center;
				bc.size = bound;
				bc.isTrigger = true;

				ed.damage = 25;

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
