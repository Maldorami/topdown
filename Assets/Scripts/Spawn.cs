using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    public int space = 30;
    public Canvas canvas;
    public GameObject healthPrefab;
    public GameObject AmmoBox;

    public Pool ZombiePool;
    public Pool ZombieFastPool;
    public Pool BomberPool;
    public Pool HealthBarPool;
    
	public void SpawnEnemy(EnemyBuilder.EnemyType type){

        GameObject enemy;

        switch (type)
        {
            case (EnemyBuilder.EnemyType.zombie):
                {
                    enemy = ZombiePool.Spawn().gameObject;
                    break;
                }
            case (EnemyBuilder.EnemyType.zombieFast):
                {
                    enemy = ZombieFastPool.Spawn().gameObject;
                    break;
                }
            case (EnemyBuilder.EnemyType.bomber):
                {
                    enemy = BomberPool.Spawn().gameObject;
                    break;
                }
            default:
                {
                    enemy = ZombiePool.Spawn().gameObject;
                    break;
                }
        }

        EnemyScreenSpaceUIScript healthBar = HealthBarPool.Spawn().gameObject.GetComponent<EnemyScreenSpaceUIScript>();
        healthBar.SetTarget(enemy);


        enemy.GetComponent<EnemyHealth>().ammobox = AmmoBox;

        Vector2 tmp = Random.insideUnitCircle;
        tmp.Normalize();
        tmp *= 35;
        Vector3 enemyPos = new Vector3(PlayerManager.instance.player.transform.position.x + tmp.x, 0, PlayerManager.instance.player.transform.position.z + tmp.y);
		enemy.transform.position = enemyPos;
	}
}
