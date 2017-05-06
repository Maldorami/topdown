using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health;
    public float MaxHealth = 100;

    float tmp;
    Animator anim;
    EnemyMovement em;
    BomberEnemyMovement bem;
    Rigidbody rg;
    BoxCollider bc;
    EnemyScreenSpaceUIScript ess;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rg = gameObject.GetComponent<Rigidbody>();
        em = gameObject.GetComponent<EnemyMovement>();
        bem = gameObject.GetComponent<BomberEnemyMovement>();
        bc = gameObject.GetComponent<BoxCollider>();
        ess = gameObject.GetComponent<EnemyScreenSpaceUIScript>();
        health = MaxHealth;
    }

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Bullet") {
			health -= hit.gameObject.GetComponent<BulletDamage>().damage;
            Destroy(hit.gameObject);
		}
	}

	void Update(){
		if (health <= 0) {
            if (em) em.isDeath = true;
            else bem.isDeath = true;

            anim.SetBool("Death", true);

            rg.velocity = Vector3.zero;
            rg.isKinematic = true;
            rg.useGravity = false;
            bc.enabled = false;

            if (ess) ess.DisableHealthPanel();

            tmp += Time.deltaTime;
            if(tmp > 2.8f) Destroy (gameObject);
		}
	}
}
