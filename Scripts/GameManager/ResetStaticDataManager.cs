using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        Arrow.ResetStaticData();
        AttackPower.ResetStaticData();
        Coin.ResetStaticData();
        Score.ResetStaticData();
        Enemy.ResetStaticData();
    }
}
