using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    [SerializeField] public AttackPower attackPower;
    [SerializeField] public Coin coins;
    [SerializeField] public Tower tree;
    [SerializeField] public PlayerSkill playerSkill;


    [SerializeField] public AudioManager sfx;
    [SerializeField] public Image gatchaImage;

    [SerializeField] public Image slotImage;

    private string nameSkill;
    private Sprite newSprite;
    private bool decisionSkill;




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

            decimal changeCost = healCost * 1 / 2;
            healCost = (int)(healCost + Math.Ceiling(changeCost));
            OnPriceHealChanged?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            sfx.Play_Wrong();
        }
    }


    public void keep()
    {
        if (decisionSkill)
        {
            playerSkill.UpdateSkills(nameSkill);
            //update slots
            slotImage.sprite = newSprite;
        }
    }


    public void threw()
    {
        nameSkill = null;
        newSprite = null;
    }

  

    public void BuySkill()
    {

        int playerCoins = coins.GetCoin();

        if (playerCoins >= healCost)
        {
            sfx.Play_Correct();


            int randomnumber = UnityEngine.Random.Range(1, 5);

            switch (randomnumber)
            {
                case 1:
                    nameSkill = "doubleArrow";
                    newSprite = Resources.Load<Sprite>("Assets/AssetS/2D/doubleArrow.png");
                    break;
                case 2:
                    nameSkill = "sniperArrow";
                    newSprite = Resources.Load<Sprite>("Assets/AssetS/2D/sniperArrow.png");

                    break;
                case 3:
                    nameSkill = "freezeArrow";
                    newSprite = Resources.Load<Sprite>("Assets/AssetS/2D/freezeArrow.png");

                    break;
                case 4:
                    nameSkill = "poisonArrow";
                    newSprite = Resources.Load<Sprite>("Assets/AssetS/2D/poisonArrow.png");

                    break;
                case 5:
                    nameSkill = "firerateArrow";
                    newSprite = Resources.Load<Sprite>("Assets/AssetS/2D/firerateArrow.png");
                    break;

                default:
                    break;
             
            }

            gatchaImage.sprite = newSprite;
            uiManager.OpenGatchaP();
      
            decimal changeCost = skillCost * 1 / 2;
            skillCost = (int)(skillCost + 10 + Math.Ceiling(changeCost));
            OnPriceSkillChanged?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            sfx.Play_Wrong();
        }
    }






}
