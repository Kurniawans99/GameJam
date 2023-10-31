using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : MonoBehaviour
{
    private int power = 10;

    public static event EventHandler OnPowerChanged;

    public static void ResetStaticData()
    {
        OnPowerChanged = null;
    }
    public void IncreasePower(int amount)
    {
        power += amount;

        OnPowerChanged?.Invoke(this, EventArgs.Empty);
        //
    }

    public int GetAttackPower()
    {
        return power;
    }

}
