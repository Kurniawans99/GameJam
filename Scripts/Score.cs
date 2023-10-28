using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;

    private void Start()
    {
        Enemy.OnEnemyDeath += Enemy_OnDeath;
    }

    private void Enemy_OnDeath(object sender, EventArgs e)
    {
        int point = UnityEngine.Random.Range(20, 50);
        score += point;

    }
}
