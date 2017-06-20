using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : MonoBehaviour
{
    public static BulletBuilder instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public GameObject Build(int damage)
    {
        GameObject go = BulletFactory.instance.Create();

        go.tag = "Bullet";

        Rigidbody rg = go.AddComponent<Rigidbody>();
        rg.useGravity = false;

        SphereCollider sc = go.AddComponent<SphereCollider>();
        sc.isTrigger = true;

        go.AddComponent<BulletMovement>();

        BulletDamage bd = go.AddComponent<BulletDamage>();
        bd.damage = damage;

        DestroyAt da = go.AddComponent<DestroyAt>();
        da.timer = 5;

        return go;
    }
}
