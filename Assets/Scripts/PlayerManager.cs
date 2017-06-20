using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float playerHealth;
    public float maxPlayerHealth = 100;
    
    public GameObject player;

    private bool isDeath = false;

	public static PlayerManager instance;
    public Rigidbody rgBody;


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
        rgBody = player.GetComponent<Rigidbody>();
	}
		
	void Update () {
		if (playerHealth <= 0) {
            if (!isDeath)
            {
			    Debug.Log("<color=red>PLAYER DEATH!</color>");
                MasterCanvasController.instance.endGame();
                isDeath = true;
            }
		}
	}

	public void attackPlayer(float value){
		playerHealth -= value;
	}
}
