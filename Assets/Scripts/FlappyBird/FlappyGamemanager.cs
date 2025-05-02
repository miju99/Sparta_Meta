using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyGamemanager : MonoBehaviour
{
    static FlappyGamemanager gameManager;
    public Button G_StartButton;

    private int currentScore = 0;
    public static FlappyGamemanager Instance
    {
        get { return gameManager; }
    }

    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
    //private int currentScore = 0;
    UIManager uiManager;

    private bool gameStart = false;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        Time.timeScale = 0f;
        uiManager.UpdateScore(0);
        uiManager.G_Start.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        if (gameStart) return;

        G_StartButton.gameObject.SetActive(false);
        gameStart = true;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        PlayerPrefs.SetInt("CurrentScore", currentScore);

        uiManager.SetGameOverUI();
    }

    public void RestartGame()
    {
        currentScore = 0;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        uiManager.UpdateScore(currentScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

        PlayerPrefs.SetInt("CurrentScore", currentScore);
        Debug.Log("Score: " + currentScore);
    }

}