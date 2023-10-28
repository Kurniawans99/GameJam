using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject GatchaPanel;
    [SerializeField]  public MarketScript market;
  

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        optionsPanel.SetActive(false);
        if(currentScene.name == "gameScene")
        {
            GatchaPanel.SetActive(false);
        }


    }
    public void PlayGame()
    {

        SceneManager.LoadScene("gameScene"); // Replace "GameScene" with the actual name of your game scene
    }
    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void Buygatcha()
    {
        market.BuySkill();
    }

    public void BuyHeal()
    {
        market.BuyHealTree();
    }
    public void BuyAp()
    {
        market.BuyAttackPower();
    }

    public void OpenGatchaP()
    {
        GatchaPanel.SetActive(true);
    }

    public void CloseGatchaP()
    {
        GatchaPanel.SetActive(false);
    }

    public void OpenOptionsAndPause()
    {
        optionsPanel.SetActive(true);
        //add pause game
    }

    public void closeTabOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        //replay game
    }
    public void ResumeGame()
    {
        //resume
    }
}
