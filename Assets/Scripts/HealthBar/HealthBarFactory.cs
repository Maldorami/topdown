using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFactory : MonoBehaviour {

    public static HealthBarFactory instance;

    private void Awake()
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
        GameObject go = Resources.Load("healthbar", typeof(GameObject)) as GameObject;
        return Instantiate(go);
    }

}
