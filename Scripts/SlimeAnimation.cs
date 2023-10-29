using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    [SerializeField] private Slime enemy;
    private Animator animator;
    private const string ENEMY_IDLE = "Idle";
    private const string ENEMY_ATTACK1 = "Attack1";
    private const string ENEMY_ATTACK2 = "Attack2";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemy.OnStateChange += Enemy_OnStateChange;
    }

    private void Enemy_OnStateChange(object sender, Slime.OnStateChangeEventArgs e)
    {
        if (e.state == Enemy.State.Attack)
        {
            animator.SetBool(ENEMY_IDLE, true);


        }
        else animator.SetBool(ENEMY_IDLE, false);
    }

    public void AttackAnimation()
    {
        int attack = UnityEngine.Random.Range(1, 3);
        if (attack == 1)
        {
            animator.SetTrigger(ENEMY_ATTACK1);
        }
        if (attack == 2)
        {
            animator.SetTrigger(ENEMY_ATTACK2);
        }
    }
}
