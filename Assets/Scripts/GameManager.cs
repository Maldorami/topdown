using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	private static GameManager instance;

	public static GameManager Instance
	{
		get 
		{
			if (instance == null)
			{
				GameObject go = new GameObject ("GameManager");
				instance = go.AddComponent<GameManager>();
			}
			return instance;
		}
	}


	void Start(){

	}

	void Update(){

	}
}
