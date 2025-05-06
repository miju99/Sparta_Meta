using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FB_UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI returnMenu;
    public Button B_ToScene;
    public Button G_Restart;
    public Button G_Start;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        if (returnMenu == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false);
        returnMenu.gameObject.SetActive(false);
        B_ToScene.gameObject.SetActive(false);
        G_Restart.gameObject.SetActive(false);
        
    }

    public void SetGameOverUI()
    {
        restartText.gameObject.SetActive(true);
        returnMenu.gameObject.SetActive(true);
        B_ToScene.gameObject.SetActive(true);
        G_Restart.gameObject.SetActive(true);
        G_Start.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}