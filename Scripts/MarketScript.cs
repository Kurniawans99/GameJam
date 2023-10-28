using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    [SerializeField] public AttackPower attackPower;
    [SerializeField] public Coin coins;
    [SerializeField] public Tower tree;

    [SerializeField] public AudioManager sfx;


    public static event EventHandler OnPriceAPChanged;
    public static event EventHandler OnPriceSkillChanged;
    public static event EventHandler OnPriceHealChanged;




    private int apCost = 10;
    private int healCost = 10;
    private int skillCost = 10;



    public int GetAPPrice()
    {
        return apCost;
    }
    public int GetSkillPrice()
    {
        return skillCost;
    }
    public int GetHealPrice()
    {
        return healCost;
    }

    //atach to Button

    public void BuyAttackPower()
    {
        int playerCoins = coins.GetCoin();

        if (playerCoins >= apCost)
        {
            sfx.Play_Correct();

            // Deduct the cost from player's coins
            coins.DeductCoins(apCost);

            // Increase Attack Power
            attackPower.IncreasePower(10);
            decimal changeCost = apCost * 1 / 2;
            apCost = (int)(apCost + Math.Ceiling(changeCost));

            OnPriceAPChanged?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            sfx.Play_Wrong();
        }
    }


    public void BuyHealTree()
    {
        int playerCoins = coins.GetCoin();

        if (playerCoins >= healCost)
        {
            sfx.Play_Correct();

            // Deduct the cost from player's coins
            coins.DeductCoins(healCost);

            // Increase Attack Power
            tree.Heal(UnityEngine.Random.Range(10, 75));
            OnPriceAPChanged?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            sfx.Play_Wrong();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public void BuySkill()
    {
        int playerCoins = coins.GetCoin();

        if (playerCoins >= healCost)
        {
            sfx.Play_Correct();

            OnPriceSkillChanged?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            sfx.Play_Wrong();
        }
    }






}
