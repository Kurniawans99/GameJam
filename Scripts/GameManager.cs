using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float playTime; // Variable to store the play time in seconds
    public static event Action<int, string, int> OnGameEnded; // Update event to include parameters
    public Score score;
    private const string HIGHSCORE = "HighScore";




    IEnumerator WaitForTwoSeconds()
    {
        Debug.Log("Before waiting");

        yield return new WaitForSeconds(3);
        EndGame();

        Debug.Log("After waiting for 2 seconds");
    }




    void Update()
    {
        playTime += Time.deltaTime; // Increment playTime every frame
    }

    public string GetPlayTimeFormatted()
    {
        int minutes = Mathf.FloorToInt(playTime / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void EndGame()
    {
        string playTimeFormatted = GetPlayTimeFormatted();
        int currentScore = score.GetScore();
        int highScore = PlayerPrefs.GetInt(HIGHSCORE);

        // Invoke the event with the parameters

        OnGameEnded?.Invoke(currentScore, playTimeFormatted, highScore);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(HIGHSCORE, currentScore);
        }
        Debug.Log("its run");
    }
}

