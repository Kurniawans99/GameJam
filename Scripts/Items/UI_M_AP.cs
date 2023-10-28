using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_M_AP : MonoBehaviour
{
    [SerializeField] private MarketScript price;
    [SerializeField] private TextMeshProUGUI priceText;
    private void Start()
    {
        priceText.text = price.GetAPPrice().ToString() + " C";
        MarketScript.OnPriceAPChanged += priceAP_OnChange;
    }

    private void priceAP_OnChange(object sender, EventArgs e)
    {
        priceText.text = price.GetAPPrice().ToString() + " C";
    }
}
