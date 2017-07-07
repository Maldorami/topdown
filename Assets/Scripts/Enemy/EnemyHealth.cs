using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health;
    public float MaxHealth;

    float tmp;

    Animator anim;
    EnemyMovement em;
    BomberEnemyMovement bem;
    Rigidbody rg;
    BoxCollider bc;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rg = gameObject.GetComponent<Rigidbody>();
        em = gameObject.GetComponent<EnemyMovement>();
        bem = gameObject.GetComponent<BomberEnemyMovement>();
        bc = gameObject.GetComponent<BoxCollider>();
    }

    void OnEnable()
    {
        health = MaxHealth;
    }  

    void OnTriggerEnter(Collider hit){
		if (hit.tag == "Bullet") {
			health -= hit.gameObject.GetComponent<BulletDamage>().damage;
		}
	}

	void Update(){
        if (health <= 0)
        {
			if (em)
				em.isDeath = true;
			else {
				bem.isDeath = true;
			}

            anim.SetBool("Death", true);

            rg.velocity = Vector3.zero;
            rg.isKinematic = true;
            rg.useGravity = false;
            bc.enabled = false;

            tmp += Time.deltaTime;
            if (tmp > 2.8f)
            {
                if (Random.Range(0, 5) == 1)
                {
					AmmoBox ab = GameObject.Find ("AmmoBoxPoolManager").GetComponent<Pool> ().Spawn ().gameObject.GetComponent<AmmoBox>();
					ab.bulletsToGive = Random.Range(20, 50);
					ab.rot = 30;
					ab.transform.position = gameObject.transform.position + Vector3.up * 1.5f;
                }

                Disable();
            }
        }
	}

    private void Disable()
    {
        rg.velocity = Vector3.zero;
        rg.isKinematic = false;
        rg.useGravity = true;
        bc.enabled = true;
		tmp = 0;
		anim.Rebind ();
		GetComponent<PoolObject>().Recycl();
    }
}
