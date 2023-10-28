using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int playerCoin = 0;
    public static event EventHandler OnCoinChanged;

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
            OnCoinChanged?.Invoke(this, EventArgs.Empty);

        }

        //Debug.Log(playerCoin);
    }
    public void DeductCoins(int amount)
    {
        
        playerCoin -= amount;
        OnCoinChanged?.Invoke(this, EventArgs.Empty);

    }
    public int GetCoin()
    {
        return playerCoin;
    }
}
