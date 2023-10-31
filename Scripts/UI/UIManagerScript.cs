using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject GatchaPanel;
    public GameObject endTabPanel;


    [SerializeField]  public MarketScript market;

   // private bool isGamePaused;


   

    private void Start()
    {
        GameManager.OnGameEnded += gameEnd;

        Scene currentScene = SceneManager.GetActiveScene();
        optionsPanel.SetActive(false);
        if(currentScene.name == "gameScene")
        {
            GatchaPanel.SetActive(false);
            endTabPanel.SetActive(false);



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

    public void gatchaKeep()
    {
        market.keep();
    }

    public void gatchaClose ()
    {
        market.threw();
        CloseGatchaP();
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
        PauseGame();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }
    public void HomeGame()
    {
        ResumeGame();
        SceneManager.LoadScene("mainScene");
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playTimeText;
    public TextMeshProUGUI highScoreText;

    public void gameEnd(int score, string playTime, int highScore)
    {
        endTabPanel.SetActive(true);
        Time.timeScale = 0.0f;

    }

}
