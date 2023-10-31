using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_M_Skill : MonoBehaviour
{
    [SerializeField] private MarketScript price;
    [SerializeField] private TextMeshProUGUI priceText;

    private void Start()
    {
        priceText.text = price.GetSkillPrice().ToString() + " C";
        MarketScript.OnPriceSkillChanged += priceSkill_OnChange;
    }

    private void priceSkill_OnChange(object sender, EventArgs e)
    {
        priceText.text = price.GetSkillPrice().ToString() + " C";
    }
}
