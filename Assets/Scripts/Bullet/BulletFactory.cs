using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour {

    public static BulletFactory instance;

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

    public GameObject Create()
    {
        GameObject go = Resources.Load("bullet", typeof(GameObject)) as GameObject;

        return Instantiate (go);
    }
}
