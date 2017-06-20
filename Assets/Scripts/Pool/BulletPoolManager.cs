using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{

    public static BulletPoolManager instance;

    [HideInInspector]
    public Pool pool;

    void Awake()
    {
        if (!instance)
        {
            instance = this;

            pool = new Pool();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
