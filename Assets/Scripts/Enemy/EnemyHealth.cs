using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;

    float tmp;
    Animator anim;
    EnemyMovement em;
    Rigidbody rg;
    BoxCollider bc;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rg = gameObject.GetComponent<Rigidbody>();
        em = gameObject.GetComponent<EnemyMovement>();
        bc = gameObject.GetComponent<BoxCollider>();
    }

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Bullet") {
			health -= 10;
            Destroy(hit.gameObject);
		}
	}

	void Update(){
		if (health <= 0) {
            em.isDeath = true;
            anim.SetBool("Death", true);

            rg.velocity = Vector3.zero;
            rg.useGravity = false;
            bc.enabled = false;

            tmp += Time.deltaTime;
            if(tmp > 2.8f) Destroy (gameObject);
		}
	}
}
