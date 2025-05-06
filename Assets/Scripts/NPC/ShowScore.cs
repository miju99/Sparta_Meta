using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowScore : MonoBehaviour
{
    public Text C_ScoreText; //�ν����� â���� UI �ؽ�Ʈ�� ����
    public Text B_ScoreText;
    private const string bestScoreKey = "BestScore"; //BestScore�� ����/����� Ű �̸�(const�� ����)
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
            //���ӸŴ������� ���� ������ �������� ���� ���� ������� ���� �� üũ
        {
            C_Score = FB_GameManager.Instance.CurrentScore; //���ӸŴ����� CurrentScore �ҷ���.
            C_ScoreText.text = C_Score.ToString();

            B_Score = FB_GameManager.Instance.BestScore;
            B_ScoreText.text = B_Score.ToString();
            Debug.Log("������ �ԷµǾ����ϴ�!");

            /*if (PlayerPrefs.HasKey(bestScoreKey)) //�ְ� ������ �ִٸ�
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
        else { Debug.Log("���� ������ �����! ������ �÷����ϼ���."); } //����======================================================================
    }
}
