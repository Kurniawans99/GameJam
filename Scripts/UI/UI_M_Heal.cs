using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_M_Heal : MonoBehaviour
{
    [SerializeField] private MarketScript price;
    [SerializeField] private TextMeshProUGUI priceText;

    private void Start()
    {
        priceText.text = price.GetHealPrice().ToString() + " C";
        MarketScript.OnPriceHealChanged += priceHeal_OnChange;
    }

    private void priceHeal_OnChange(object sender, EventArgs e)
    {
        priceText.text = price.GetHealPrice().ToString() + " C";
    }
}
