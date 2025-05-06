using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FB_GameManager : MonoBehaviour
{
    public static FB_GameManager gameManager; //�ڽ��� ������ �� �ִ� static ����
    public Button G_StartButton;

    private int currentScore = 0;
    public static FB_GameManager Instance //���ӸŴ��� �̱��� ������ �ܺη� ������ �� �ְ� �ϴ� ������Ƽ(Instance)
    {
        get { return gameManager; }
    }

    public int CurrentScore //currentScore�� ������ �����ϰ�, CurrentScore�� �ҷ��� �� ����.
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    public int BestScore
    {
        get { return PlayerPrefs.GetInt("BestScore", 0); }
    }

    FB_UIManager uiManager;

    private bool gameStart = false;

    public FB_UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        gameManager = this; //gameManager �̱����� �������� ���� (��ü ����)
        uiManager = FindObjectOfType<FB_UIManager>(); //UIManager ã�ƿ���

        /*
        if(gameManager != null && gameManager != this) //�ߺ����� �ʵ��� Ȯ��
        {
            Destroy(this.gameObject);
            return;
        }
        gameManager = this;
        DontDestroyOnLoad(this.gameObject); //�� ��ȯ�� �ı����� �ʵ��� ����
        */
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("CurrentScore", 0); //���� ���� �� ���� �ʱ�ȭ
       // Debug.Log("��ŸƮ!");
        Time.timeScale = 0f;
        uiManager.UpdateScore(0); //ó���� �������� ���� 0�� �����
        uiManager.G_Start.onClick.AddListener(StartGame); //UI ��ư Ŭ�� �� �Լ� ����
    }

    private void StartGame()
    {
        if (gameStart) return; //������ �� ���� �����ϱ� ����

        G_StartButton.gameObject.SetActive(false); //��ư ��Ȱ��ȭ
        gameStart = true; //������ ���۵� �������� �˸�.
        Time.timeScale = 1f; //���� ����(�ð� �帧)
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        PlayerPrefs.SetInt("CurrentScore", currentScore); //���� ���� �� ���� ����
        float bestScore = PlayerPrefs.GetInt("BestScore", 0); //bestScore�� ������ 0�� ���
        if (currentScore > bestScore) //���� ������ ũ��
        {
            PlayerPrefs.SetInt("BestScore", currentScore); //Bestscore�� ���� ������ �ִ´�.
        }

        uiManager.SetGameOverUI();
    }

    public void RestartGame() //���� �����(���� �ٽ� �Ѵ� �۾�)
    {
        currentScore = 0;
       //PlayerPrefs.SetInt("CurrentScore", currentScore); //���� ����� �� ���� 0���� �ٲٱ�
        uiManager.UpdateScore(currentScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //���� �����ִ� ���� �ٽ� ��
    }

    public void ReturnMenu()
    {
        //PlayerPrefs.SetInt("CurrentScore", currentScore); //���� ����
        SceneManager.LoadScene("MainScene");
    }


    public void AddScore(int score) //���� �߰�
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

        //PlayerPrefs.SetInt("CurrentScore", currentScore);
        //Debug.Log("���� ���ھ� =  " + currentScore);
    }

}