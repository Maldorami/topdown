using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAt : MonoBehaviour {

	public float timer = 5;
	float tmp;

    void OnEnable()
    {
        tmp = 0;
    }

	void Update () {
		tmp += Time.deltaTime;

		if (tmp > timer) {
            GetComponent<PoolObject>().Recycl();
		}
	}
}
