using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static event EventHandler OnEnemyDeath;
    public Transform target;

    public enum State
    {
        Chase,
        Attack
    }
    public State state;

    public float health;
    public float speed;
    public NavMeshAgent agent;
    private Coroutine poisonCoroutine = null;

    public virtual void Attack()
    {
        Debug.Log("Attack From EnemyParentClass");
    }
    public void TakenDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnEnemyDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
    public void Burning(PlayerSkill skill, float burnDamage)
    {
        if (poisonCoroutine != null)
        {
            StopCoroutine(poisonCoroutine);
        }
        poisonCoroutine = StartCoroutine(skill.Poison(this, burnDamage));

    }
}
