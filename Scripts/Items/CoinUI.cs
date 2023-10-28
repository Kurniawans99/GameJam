using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField]private TextMeshProUGUI coinText;
    private void Start()
    {
        coinText.text = "0";
        Coin.OnCoinChanged += Coin_OnChange;
    }

    private void Coin_OnChange(object sender, EventArgs e)
    {
        coinText.text =coin.GetCoin().ToString();
    }
}
