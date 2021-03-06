﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public Animator anim;

    float AttackTimer;
    float tmp = 0;
    bool attack = true;
    bool move = true;
    bool distanceToDamage = false;

    EnemyDamage ed;
    Enemy en;
    public bool isDeath;

    NavMeshAgent nma;

    GameObject player;
    Rigidbody rg;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        ed = GetComponent<EnemyDamage>();
        en = GetComponent<Enemy>();
        nma = GetComponent<NavMeshAgent>();
        nma.speed = speed;
    }

    void OnEnable()
    {
        tmp = 0;
        attack = true;
        move = true;
        distanceToDamage = false;
        isDeath = false;
    }


    void Update()
    {
        Vector3 look = PlayerManager.instance.player.transform.position;

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
                nma.destination = look;
                nma.speed = speed;
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
                    nma.speed = 0.00001f;
                }
                else
                {
                    if (distanceToDamage && tmp > .25f)
                    {
                        Debug.Log("<color=yellow>zombie attack!</color>");
                        ed.DoDamageToPlayer();
                        tmp = 0;
                    }
                }

                AttackTimer += Time.deltaTime;
                if (AttackTimer > .5f)
                {
                    move = true;
                    attack = true;
                    AttackTimer = 0;
                    tmp = 0;
                }

                if (move)
                    rg.isKinematic = true;
                else
                    rg.isKinematic = false;
            }
        }
        else
        {
            nma.speed = 0.00001f;
        }
    }
}
