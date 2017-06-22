using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Zombie,
    ZombieFast,
    Bomber,
    Bullet,
    HealthBar
}

public class Pool : MonoBehaviour {

    public PoolType type;

    public int count = 10;

    private List<PoolObject> objects = new List<PoolObject>();

	void Awake () {
        for (int i = 0; i < count; i++)
        {
            PoolObject po = Create();
            po.gameObject.SetActive(false);
            objects.Add(po);
        }
	}
	
	public PoolObject Create () {

        GameObject go;

        switch (type)
        {
            case (PoolType.Zombie):
                {
                    go = EnemyBuilder.Instance.Build(EnemyBuilder.EnemyType.zombie);
                    break;
                }
            case (PoolType.ZombieFast):
                {
                    go = EnemyBuilder.Instance.Build(EnemyBuilder.EnemyType.zombieFast);
                    break;
                }
            case (PoolType.Bomber):
                {
                    go = EnemyBuilder.Instance.Build(EnemyBuilder.EnemyType.bomber);
                    break;
                }
            case (PoolType.Bullet):
                {
                    go = BulletBuilder.instance.Build(10);
                    break;
                }
            case (PoolType.HealthBar):
                {
                    go = HealthBarBuilder.instance.Build();
                    break;
                }
            default:
                {
                    go = EnemyBuilder.Instance.Build(EnemyBuilder.EnemyType.zombie);
                    break;
                }
        }
        
        PoolObject po = go.AddComponent<PoolObject>();
        po.SetPool(this);
        go.transform.parent = transform;

        return po;
    }

    public PoolObject Spawn()
    {
        PoolObject po = null;

        if (objects.Count > 0)
        {
            po = objects[0];
            po.gameObject.SetActive(true);
            objects.RemoveAt(0);
        }
        else
            po = Create();

        return po;
    }

    public void Recycl(PoolObject po)
    {
        po.gameObject.SetActive(false);
        objects.Add(po);
    }
}
