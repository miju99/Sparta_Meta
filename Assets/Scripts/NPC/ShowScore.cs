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

        if (PlayerPrefs.HasKey(bestScoreKey)) //�ְ� ������ �ִٸ�
        {
            bestScore = PlayerPrefs.GetFloat("BestScore"); //�ְ� ������ �ҷ��´�.

            if (CurrentScore > bestScore) //�ְ� ������ ���� �������� ������
            {
                PlayerPrefs.SetFloat("BestScore", CurrentScore); //���� ������ �ְ� ������ ����.
                scoreText.text = CurrentScore.ToString(); //���� ������ �ְ� ������ ������
            }
            else //�ְ� ������ ���� �������� ũ��!
            {
                // �ְ� ���� ���
                scoreText.text = bestScore.ToString(); //���� ������ �ְ� ������ ������
            }
        }
        else //�ְ� ������ ���ٸ�
        {
            PlayerPrefs.SetFloat("BestScore", CurrentScore);
            scoreText.text = CurrentScore.ToString(); //���� ������ �ְ� ������ ������
        }*/
    }
}
