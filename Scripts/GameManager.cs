using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float playTime; // Variable to store the play time in seconds

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
}
