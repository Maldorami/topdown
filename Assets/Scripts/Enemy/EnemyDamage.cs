using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float damage = 100;

	public void DoDamageToPlayer(){
		PlayerManager.instance.attackPlayer (damage);
	}
}
