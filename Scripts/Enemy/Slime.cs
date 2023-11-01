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
        public State state;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindAnyObjectByType<Tower>().transform;
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
        if (target == null) return;
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
        if (Tower.Instance != null)
        {

            Tower.Instance.TakenDamage(damage);
        }
    }


}
