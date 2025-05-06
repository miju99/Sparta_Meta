using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FB_Looper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        FB_Obstacle[] obstacles = GameObject.FindObjectsOfType<FB_Obstacle>();
          //GameObject.FindObjectsOfType<FB_Obstacle>() : ���� �ִ� ��� FB_Obstacle ��ü�� ã�� �迭�� ��ȯ
          //FindObjectOfType : <T>Ÿ���� ��� ��ü�� ã�� �迭�� ��ȯ

        obstacleLastPosition = obstacles[0].transform.position;
        //�迭�� ù ��° ��ü�� ���� ��ġ ��ȯ
        //obstacleLastPosition : ù ��° ��ü�� ��ġ ����

        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
              //�ݺ����� ���鼭 ��ġ�� �������� ����
              //Obstacle�� ��ġ�� �Ǹ� ��ġ�� ��ġ�� �޾� ���� Obstacle�� ��ġ�� �� ����.
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) //�浹 ó���Ǹ� ��� �ڷ� ����.
        //trigger�� �浹�� ���� ������ �� �� ����, �浹ü�� ���� ������ �ش�!
    {
        //Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = collision.bounds.size.x;
              //������ ������Ʈ���� ������ ��������
              //vollision.bounds : collider�� ��踦 ��Ÿ�� = ũ�⸦ �����ϰ� �ִ�!
              //x�� ����� ���ϱ� ������ ������ ũ�⸦ ���ϰ� ��.

            Vector3 pos = collision.transform.position;
              //�浹�� ������Ʈ�� ��ġ ��������

            pos.x += widthOfBgObject * numBgCount;
              //���� ������ * ����
            collision.transform.position = pos;
            return; //BackGround�� ó���� �߱� ������ (Obstacle�� �� �� ����!) ���̻� �������� �ʵ���
        }

        FB_Obstacle obstacle = collision.GetComponent<FB_Obstacle>();
          //�浹ü���� obstacle�� �ִ� �� Ȯ��
        if (obstacle) //obstacle�� null�� �ƴ϶��
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
              //���� ���� ����!
        }
    }
}