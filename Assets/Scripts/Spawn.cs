using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public int space = 30;
    public Canvas canvas;
    public GameObject healthPrefab;
    public GameObject AmmoBox;
    
	public void SpawnEnemy(EnemyBuilder.EnemyType type){
		GameObject enemy = EnemyBuilder.Instance.Build (type);

        EnemyScreenSpaceUIScript ess = enemy.GetComponent<EnemyScreenSpaceUIScript>();
        ess.canvas = canvas;
        ess.healthPrefab = healthPrefab;

        enemy.GetComponent<EnemyHealth>().ammobox = AmmoBox;

        Vector2 tmp = Random.insideUnitCircle;
        tmp.Normalize();
        tmp *= 35;
        Vector3 enemyPos = new Vector3(PlayerManager.instance.player.transform.position.x + tmp.x, 0, PlayerManager.instance.player.transform.position.z + tmp.y);
		enemy.transform.position = enemyPos;
	}
}
