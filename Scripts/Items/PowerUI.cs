using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUI : MonoBehaviour
{
    [SerializeField] private AttackPower attackPower;
    [SerializeField] private TextMeshProUGUI apText;
    private void Start()
    {
        apText.text = attackPower.GetAttackPower().ToString();
        AttackPower.OnPowerChanged += Power_OnChange;
    }

    private void Power_OnChange(object sender, EventArgs e)
    {
        apText.text = attackPower.GetAttackPower().ToString();
        Debug.Log("test");
    }
}
