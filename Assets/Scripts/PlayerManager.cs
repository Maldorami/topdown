using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float playerHealth = 100;

	public static PlayerManager instance;
	void Awake()
	{
		if (!instance) {
			instance = this;
		}
	}
		
	void Update () {
		if (playerHealth <= 0) {
			Debug.Log("<color=red>PLAYER DEATH!</color>");
		}
	}

	public void attackPlayer(float value){
		playerHealth -= value;
	}
}
