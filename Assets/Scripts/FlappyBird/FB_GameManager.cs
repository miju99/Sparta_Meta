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
    public static FB_GameManager gameManager; //자신을 참조할 수 있는 static 변수
    public Button G_StartButton;

    private int currentScore = 0;
    public static FB_GameManager Instance //게임매니저 싱글톤 변수를 외부로 가져갈 수 있게 하는 프로퍼티(Instance)
    {
        get { return gameManager; }
    }

    public int CurrentScore //currentScore에 점수를 저장하고, CurrentScore로 불러올 수 있음.
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
        gameManager = this; //gameManager 싱글톤이 본인임을 선언 (객체 설정)
        uiManager = FindObjectOfType<FB_UIManager>(); //UIManager 찾아오기

        /*
        if(gameManager != null && gameManager != this) //중복되지 않도록 확인
        {
            Destroy(this.gameObject);
            return;
        }
        gameManager = this;
        DontDestroyOnLoad(this.gameObject); //씬 전환에 파괴되지 않도록 유지
        */
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("CurrentScore", 0); //게임 시작 시 점수 초기화
       // Debug.Log("스타트!");
        Time.timeScale = 0f;
        uiManager.UpdateScore(0); //처음에 시작했을 때는 0점 만들기
        uiManager.G_Start.onClick.AddListener(StartGame); //UI 버튼 클릭 시 함수 실행
    }

    private void StartGame()
    {
        if (gameStart) return; //게임을 한 번만 실행하기 위해

        G_StartButton.gameObject.SetActive(false); //버튼 비활성화
        gameStart = true; //게임이 시작된 상태임을 알림.
        Time.timeScale = 1f; //게임 시작(시간 흐름)
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        PlayerPrefs.SetInt("CurrentScore", currentScore); //게임 오버 시 점수 저장
        float bestScore = PlayerPrefs.GetInt("BestScore", 0); //bestScore이 없으면 0을 출력
        if (currentScore > bestScore) //현재 점수가 크면
        {
            PlayerPrefs.SetInt("BestScore", currentScore); //Bestscore에 현재 점수를 넣는다.
        }

        uiManager.SetGameOverUI();
    }

    public void RestartGame() //게임 재시작(씬을 다시 켜는 작업)
    {
        currentScore = 0;
       //PlayerPrefs.SetInt("CurrentScore", currentScore); //게임 재시작 시 점수 0으로 바꾸기
        uiManager.UpdateScore(currentScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 켜져있는 씬을 다시 켬
    }

    public void ReturnMenu()
    {
        //PlayerPrefs.SetInt("CurrentScore", currentScore); //점수 저장
        SceneManager.LoadScene("MainScene");
    }


    public void AddScore(int score) //점수 추가
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

        //PlayerPrefs.SetInt("CurrentScore", currentScore);
        //Debug.Log("현재 스코어 =  " + currentScore);
    }

}