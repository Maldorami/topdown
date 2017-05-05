using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -28, 28), transform.position.y, Mathf.Clamp(transform.position.z, -28, 28));

	}
}
