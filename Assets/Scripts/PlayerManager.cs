using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float playerHealth;
    public float maxPlayerHealth = 100;
    
    public GameObject player;


	public static PlayerManager instance;
	void Awake()
	{
		if (!instance) {
			instance = this;
		}
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = maxPlayerHealth;
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
