using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public int space = 30;

	public void SpawnEnemy(EnemyBuilder.EnemyType type){
		GameObject enemy = EnemyBuilder.Instance.Build (type);
        Vector2 tmp = Random.insideUnitCircle * 35;
        Vector3 enemyPos = new Vector3(PlayerManager.instance.player.transform.position.x + tmp.x, 0, PlayerManager.instance.player.transform.position.z + tmp.y);
		enemy.transform.position = enemyPos;
	}
}
