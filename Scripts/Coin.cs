using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int playerCoin = 0;

    private void Start()
    {
        Enemy.OnEnemyDeath += Enemy_OnDeath;
    }

    private void Enemy_OnDeath(object sender, EventArgs e)
    {
        int dropRate = UnityEngine.Random.Range(0, 2);
        if (dropRate == 1)
        {
            int coinDrop = UnityEngine.Random.Range(15, 25);
            playerCoin += coinDrop;
        }

        Debug.Log(playerCoin);
    }

}
