using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health;
    public float MaxHealth = 100;

    float tmp;
    public GameObject ammobox;

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
            if (em) em.isDeath = true;
            else bem.isDeath = true;

            anim.SetBool("Death", true);

            rg.velocity = Vector3.zero;
            rg.isKinematic = true;
            rg.useGravity = false;
            bc.enabled = false;

            tmp += Time.deltaTime;
            if (tmp > 2.8f)
            {
                if (Random.Range(0, 5) == 0)
                {
                    ammobox.GetComponent<AmmoBox>().bulletsToGive = Random.Range(20, 50);
                    Instantiate(ammobox, transform.position, transform.rotation);
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
                GetComponent<PoolObject>().Recycl();

    }
}
