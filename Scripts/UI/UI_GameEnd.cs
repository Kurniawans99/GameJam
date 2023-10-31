using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UI_GameEnd : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI playTimeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;


    private void Start()
    {
        playTimeText.text = "00:00";
        GameManager.OnGameEnded += Game_OnEnded;

    }


    private void Game_OnEnded(int score, string playTime, int highScore)
    {
        // Update UI with the provided parameters
        scoreText.text = score.ToString();
        playTimeText.text = playTime;

        if (score > highScore)
        {
            highScore = score;
        }

        highScoreText.text = highScore.ToString();
    }
}
