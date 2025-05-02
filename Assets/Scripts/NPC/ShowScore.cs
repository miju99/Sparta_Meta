using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;
    private const string bestScoreKey = "BestScore";

    void Start()
    {
        /*int CurrentScore = FlappyGamemanager.Instance.CurrentScore;
        float bestScore = 0f;

        if (PlayerPrefs.HasKey(bestScoreKey)) //최고 점수가 있다면
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
}
