using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUpgrade : MonoBehaviour
{
    public static StatusUpgrade Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void UpgradeFireRate(float percentage)
    {
        if (Bow.Instance.fireRate < 0.1f) return;
        Bow.Instance.fireRate -= percentage;
    }

    public void UpgradeArrowDamage(float additionalDamage)
    {

    }
    public void UpgradeBurnDamage(float additionalBurnDamage)
    {

    }
    public void UpgradeSlow(float additionalSlow)
    {

    }

}
