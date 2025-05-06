using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowScore : MonoBehaviour
{
    public Text C_ScoreText; //인스펙터 창에서 UI 텍스트와 연결
    public Text B_ScoreText;
    private const string bestScoreKey = "BestScore"; //BestScore을 저장/사용할 키 이름(const로 고정)
    private int C_Score;
    private int B_Score;

    private void Start()
    {
        C_Score = PlayerPrefs.GetInt("CurrentScore", 0);
        C_ScoreText.text = C_Score.ToString();

        B_Score = PlayerPrefs.GetInt("BestScore", 0);
        B_ScoreText.text = B_Score.ToString();
    }

    void Update()
    {
        if (FB_GameManager.Instance != null)
            //게임매니저에서 현재 점수를 가져오기 위해 값이 비어있지 않은 지 체크
        {
            C_Score = FB_GameManager.Instance.CurrentScore; //게임매니저의 CurrentScore 불러옴.
            C_ScoreText.text = C_Score.ToString();

            B_Score = FB_GameManager.Instance.BestScore;
            B_ScoreText.text = B_Score.ToString();
            Debug.Log("점수가 입력되었습니다!");

            /*if (PlayerPrefs.HasKey(bestScoreKey)) //최고 점수가 있다면
            {
                bestScore = PlayerPrefs.GetFloat("BestScore"); //최고 점수를 불러온다.

                if (CurrentScore > bestScore) //최고 점수가 지금 점수보다 작으면
                {
                    PlayerPrefs.SetFloat("BestScore", CurrentScore); //현재 점수를 최고 점수에 저장.
                    scoreText.text = CurrentScore.ToString(); //현재 점수를 최고 점수에 보여줌
                }
                else //최고 점수가 지금 점수보다 크면!
                {
                    // 최고 점수 출력
                    scoreText.text = bestScore.ToString(); //현재 점수를 최고 점수에 보여줌
                }
            }
            else //최고 점수가 없다면
            {
                PlayerPrefs.SetFloat("BestScore", CurrentScore);
                scoreText.text = CurrentScore.ToString(); //현재 점수를 최고 점수에 보여줌
            }*/
        }
        else { Debug.Log("현재 점수가 없어요! 게임을 플레이하세요."); } //수정======================================================================
    }
}
