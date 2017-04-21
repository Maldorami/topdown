using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 500000;
    public float rotationSpeed = 50;
    Rigidbody rg;

    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 tmp2 = InputManager.instance.Movement();
        tmp2 = transform.InverseTransformDirection (tmp2);
        gameObject.transform.Translate(tmp2 * speed * Time.deltaTime);

        Vector3 tmp = InputManager.instance.Look();
        tmp.y = gameObject.transform.position.y;
        gameObject.transform.LookAt(tmp);

    }
}