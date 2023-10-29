using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Image bar;
    private float maxHealth;

    private void Start()
    {
        bar.fillAmount = 1f;
        maxHealth = enemy.health;
        enemy.OnHit += Enemy_Hit;
    }

    private void Enemy_Hit(object sender, EventArgs e)
    {
        bar.fillAmount = enemy.health / maxHealth;
    }
}
