using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemyMovement : MonoBehaviour
{
	public float speed;
	public Animator anim;

	float AttackTimer;
	float tmp = 0;
	bool attack = true;
	bool move = true;
	bool distanceToDamage = false;

	BomberDamage ed;
    Enemy en;
    public bool isDeath;

    bool alreadyAttack = false;

	GameObject player;
	Rigidbody rg;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rg = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
        ed = GetComponent<BomberDamage>();
        en = GetComponent<Enemy>();
	}

	void Update () {
		Vector3 look = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

        if (!isDeath)
        {
            if (Vector3.Distance(transform.position, look) < 2)
            {
                distanceToDamage = true;
            }
            else
            {
                distanceToDamage = false;
            }

            if (!distanceToDamage && move)
            {
                transform.LookAt(look);
                rg.velocity = (transform.forward * speed);
            }
            else
            {
                tmp += Time.deltaTime;

                if (attack)
                {
                    anim.SetTrigger("Attacking");
                    attack = false;
                    move = false;
                    rg.velocity = Vector3.zero;
                }
                else
                {
                    if (tmp > .5f)
                    {
                        if (!alreadyAttack)
                        {
                            Debug.Log("<color=yellow>Explotion incoming!</color>");
                            ed.Attack(distanceToDamage);
                            tmp = 0;

                            alreadyAttack = true;
                        }
                    }
                }
            }
        }
        else
        {

        }
	}
}

