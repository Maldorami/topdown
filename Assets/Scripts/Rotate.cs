using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float Speed;
    public float rotY;

    void Update()
    {
        rotY = gameObject.transform.rotation.y;
        if (gameObject.transform.rotation.y >= 0.4821559)
        gameObject.transform.Rotate(0, Speed * Time.deltaTime, 0);
    }
}
