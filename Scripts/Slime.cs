using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Slime : Enemy
{
    public event EventHandler<OnStateChangeEventArgs> OnStateChange;
    public class OnStateChangeEventArgs : EventArgs
    {
        public State state = State.Chase;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        state = State.Chase;
        health = 100f;
        speed = 2f;
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
                OnStateChange?.Invoke(this, new OnStateChangeEventArgs
                {
                    state = state
                });
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
            OnStateChange?.Invoke(this, new OnStateChangeEventArgs
            {
                state = state
            });

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

    public void AttackDamage()
    {
        int damage = UnityEngine.Random.Range(20, 40);
        Tower.Instance.TakenDamage(damage);
    }


}
