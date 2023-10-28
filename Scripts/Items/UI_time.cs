using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_time : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI playTimeText;

    private void Start()
    {
        playTimeText.text = "00:00";
    }

    private void Update()
    {
        playTimeText.text = gameManager.GetPlayTimeFormatted();
    }
}
