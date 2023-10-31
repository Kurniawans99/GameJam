using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static event EventHandler OnEnemyDeath;
    public static void ResetStaticData()
    {
        OnEnemyDeath = null;
    }
    public event EventHandler OnHit;
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
        OnHit?.Invoke(this, EventArgs.Empty);
        if (health <= 0)
        {
            OnEnemyDeath?.Invoke(this, EventArgs.Empty);
            EnemySpawn.Instance.EnemyDecrease(1);
            Destroy(gameObject);
        }
    }
    public void Burning(PlayerSkill skill, float burnDamage)
    {
        Debug.Log("oi");
        if (poisonCoroutine != null)
        {
            StopCoroutine(poisonCoroutine);
        }
        poisonCoroutine = StartCoroutine(skill.Poison(this, burnDamage));

    }
}
