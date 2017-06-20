using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 15;

    Rigidbody rg;
    Rigidbody playerRG;

    Vector3 velocity;

    void OnEnable()
    {
        rg = GetComponent<Rigidbody>();
        rg.isKinematic = false;
        playerRG = PlayerManager.instance.rgBody;
    }
    void OnDisable()
    {
        rg.isKinematic = true;
        rg.velocity = Vector3.zero;
    }

    void Update()
    {
        velocity = transform.forward * speed + playerRG.velocity;
        rg.velocity = (velocity);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag != "Player" && hit.tag != "Bullet")
            GetComponent<PoolObject>().Recycl();
    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag != "Player" && hit.gameObject.tag != "Bullet")
            GetComponent<PoolObject>().Recycl();
    }
}
