using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBuilder : MonoBehaviour {

    public static HealthBarBuilder instance;

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

    public GameObject Build()
    {
        GameObject go = HealthBarFactory.instance.Create();
        go.AddComponent<EnemyScreenSpaceUIScript>();
        return go;
    }

}
