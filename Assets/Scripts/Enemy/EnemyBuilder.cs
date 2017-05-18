using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
		zombieFast,
		bomber
	}

	public GameObject Build (EnemyType type){

		GameObject go = EnemyFactory.Instance.Create (type);

		switch (type) {
		case (EnemyType.zombie):{
				Rigidbody rg = go.AddComponent<Rigidbody> ();
				BoxCollider bc = go.AddComponent<BoxCollider> ();
				EnemyDamage ed = go.AddComponent<EnemyDamage> ();
                Enemy et = go.AddComponent<Enemy>();
                et.type = type;
				EnemyHealth eh = go.AddComponent<EnemyHealth> ();
                EnemyScreenSpaceUIScript ess = go.AddComponent<EnemyScreenSpaceUIScript>();

                NavMeshAgent nma = go.AddComponent<NavMeshAgent>();
                nma.radius = 0.06f;
                nma.height = 0.18f;
				nma.stoppingDistance = 0f;
				nma.acceleration = 100f;

				EnemyMovement enmMov = go.AddComponent<EnemyMovement>();
				rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

				Vector3 bound = new Vector3 (0.1f, 0.1f, 0.1f);
				Vector3 center = new Vector3 (0, .1f, .02f);
				bc.center = center;
				bc.size = bound;
				bc.isTrigger = true;

				enmMov.speed = 2;
				ed.damage = 30;
                eh.MaxHealth = 200;
                    

                go.tag = "Enemy";
				return go;
			}
        case (EnemyType.zombieFast):
            {
                Rigidbody rg = go.AddComponent<Rigidbody>();
                BoxCollider bc = go.AddComponent<BoxCollider>();
                EnemyDamage ed = go.AddComponent<EnemyDamage>();
                Enemy et = go.AddComponent<Enemy>();
                et.type = type;
                EnemyHealth eh = go.AddComponent<EnemyHealth>();
                EnemyScreenSpaceUIScript ess = go.AddComponent<EnemyScreenSpaceUIScript>();

                NavMeshAgent nma = go.AddComponent<NavMeshAgent>();
                nma.radius = 0.06f;
                nma.height = 0.18f;
				nma.stoppingDistance = 0f;
				nma.acceleration = 100f;

                EnemyMovement enmMov = go.AddComponent<EnemyMovement>();
                rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

                Vector3 bound = new Vector3(0.1f, 0.1f, 0.1f);
                Vector3 center = new Vector3(0, .1f, .02f);
                bc.center = center;
                bc.size = bound;
                bc.isTrigger = true;

                enmMov.speed = 10;
                ed.damage = 10;
                eh.MaxHealth = 100;              

                go.tag = "Enemy";
                return go;
			}
        case (EnemyType.bomber):
            {
                Rigidbody rg = go.AddComponent<Rigidbody>();
                BoxCollider bc = go.AddComponent<BoxCollider>();
                BomberDamage ed = go.AddComponent<BomberDamage>();
                Enemy et = go.AddComponent<Enemy>();
                et.type = type;
                EnemyHealth eh = go.AddComponent<EnemyHealth>();
                EnemyScreenSpaceUIScript ess = go.AddComponent<EnemyScreenSpaceUIScript>();

                NavMeshAgent nma = go.AddComponent<NavMeshAgent>();
                nma.radius = 0.06f;
                nma.height = 0.18f;
				nma.stoppingDistance = 0f;
				nma.acceleration = 100f;

                BomberEnemyMovement enmMov = go.AddComponent<BomberEnemyMovement>();
                rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

                Vector3 bound = new Vector3(0.1f, 0.1f, 0.1f);
                Vector3 center = new Vector3(0, .1f, .02f);
                bc.center = center;
                bc.size = bound;
                bc.isTrigger = true;

                enmMov.speed = 12;
                ed.damage = 75;
                eh.MaxHealth = 150;              

                go.tag = "Enemy";
                return go;
			}
		}

		return null;
	}
}
