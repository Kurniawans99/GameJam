using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private Image bar;

     private void Start()
    {
        Tower.Instance.OnTreeHit += Tower_OnHit;
        bar.fillAmount = 1f;
    }

    private void Tower_OnHit(object sender, Tower.OnTreeHitEventArgs e)
    {
        Debug.Log(e.currentHealth);
        bar.fillAmount = Tower.Instance.health/Tower.Instance.GetMaxHealth();
    }
}
