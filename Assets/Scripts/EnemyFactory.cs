using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

	private static EnemyFactory instance;

	public static EnemyFactory Instance
	{
		get 
		{
			if (instance == null)
			{
				GameObject go = new GameObject ("EnemyFactory");
				instance = go.AddComponent<EnemyFactory>();
			}
			return instance;
		}
	}


	public GameObject Create(EnemyBuilder.EnemyType type){

		switch (type) {
		case (EnemyBuilder.EnemyType.zombie):{
				GameObject go = Resources.Load ("zombie", typeof(GameObject)) as GameObject;
				return Instantiate (go);
			}
		case (EnemyBuilder.EnemyType.zombieFast):{
				GameObject go = Resources.Load ("zombieFast", typeof(GameObject)) as GameObject;
				return Instantiate (go);
			}
        case (EnemyBuilder.EnemyType.bomber):
            {
				GameObject go = Resources.Load ("bomber", typeof(GameObject)) as GameObject;
				return Instantiate (go);
			}
		}

		return null;
	}

}
