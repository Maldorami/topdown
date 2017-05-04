using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public int space = 5;

	public void SpawnEnemy(){
		GameObject enemy = EnemyBuilder.Instance.Build (EnemyBuilder.EnemyType.zombie);
        Vector3 enemyPos = new Vector3(gameObject.transform.position.x + Random.Range(-space, space), gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-space, space));
		enemy.transform.position = enemyPos;
	}

}
