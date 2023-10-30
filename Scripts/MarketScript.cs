using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

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

    string path;
    private string nameSkill;
    private Sprite newSprite;
    private bool decisionSkill;




    public static event EventHandler OnPriceAPChanged;
    public static event EventHandler OnPriceSkillChanged;
    public static event EventHandler OnPriceHealChanged;




    private int apCost = 10;
    private int healCost = 10;
    private int skillCost = 10;

    private void Start()
    {
        path = "MY";
        Color imageColor = slotImage.color;
        imageColor.a = 0.0f; // Set the alpha value to 0.5 for 50% transparency
        slotImage.color = imageColor;
    }

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
            tree.Heal(UnityEngine.Random.Range(100, 250));

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
            Color imageColor = slotImage.color;
            imageColor.a = 1.0f; // Set the alpha value to 0.5 for 50% transparency
            slotImage.color = imageColor;


            playerSkill.UpdateSkills(nameSkill);
            slotImage.sprite = newSprite;
            threw();
        }
    }


    public void threw()
    {
        decisionSkill = false;

        nameSkill = null;
        newSprite = null;
    }

  

    public void BuySkill()
    {

        int playerCoins = coins.GetCoin();

        if (playerCoins >= skillCost)
        {
            sfx.Play_Correct();
            coins.DeductCoins(skillCost);


            int randomnumber = UnityEngine.Random.Range(1, 100);
            Debug.Log(randomnumber);


            switch (randomnumber)
            {
                case >= 1 and <= 10: // 10% chance
                    nameSkill = "doubleArrow";
                    path = "Assets/AssetS/2D/doubleArrow.png";
                    break;
                case >= 11 and <= 40: // 30% chance (increased from 30)
                    nameSkill = "sniperArrow";
                    path = "Assets/AssetS/2D/sniperArrow.png";
                    break;
                case >= 41 and <= 70: // 30% chance
                    nameSkill = "freezeArrow";
                    path = "Assets/AssetS/2D/freezeArrow.png";
                    break;
                case >= 71 and <= 85: // 15% chance
                    nameSkill = "poisonArrow";
                    path = "Assets/AssetS/2D/poisonArrow.png";
                    break;
                case >= 86 and <= 100: // 15% chance
                    nameSkill = "firerateArrow";
                    path = "Assets/AssetS/2D/firerateArrow.png";
                    break;
                default:
                    break;
            }

            decisionSkill = true;
            newSprite = Resources.Load<Sprite>("MySprite");


            if (newSprite != null)
            {
                gatchaImage.sprite = newSprite;
                Debug.Log("Image changed successfully.");
            }
            else
            {
                Debug.LogWarning("Failed to load sprite.");
            }
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
