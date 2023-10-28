using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        scoreText.text = "0";
        Score.OnScoreChanged += Score_OnChange;
    }

    private void Score_OnChange(object sender, EventArgs e)
    {
        scoreText.text = score.GetScore().ToString();
    }
}
