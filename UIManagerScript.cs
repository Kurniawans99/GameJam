using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject GatchaPanel;
  

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
        /* 
        if(money >= price)
        {
            //start gatch (call script gatcha && play sound correct)
            OpenGatchaP();
        }
        else
        {
            //denied gatch (call script gatcha && play sound false)

        }
        */
    }
    /*
     public void BuyHeal()
     public void BuyAp()
    */


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
