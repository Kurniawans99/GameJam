using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Slime : Enemy
{
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        state = State.Chase;
        health = 100f;
        speed = 5f;
        agent.speed = speed;
    }

    private void Update()
    {
        if (state == State.Chase)
        {
            agent.destination = target.position;

            if (CanAttack())
            {
                state = State.Attack;
            }
        }
        else if (state == State.Attack)
        {
            Attack();
        }
    }
    public override void Attack()
    {
        //Attack IN Here

        if (CanAttack() == false)
        {
            state = State.Chase;
        }
    }



    private bool CanAttack()
    {
        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            return true;
        }
        else return false;
    }
}
