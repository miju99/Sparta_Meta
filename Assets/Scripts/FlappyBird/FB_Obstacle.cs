using UnityEngine;
using Random = UnityEngine.Random;

public class FB_Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;
      // Obstacle�� ���Ϸ� �̵��� �� �󸶳� �̵��� ��

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;
      //top�� bottom���̿� ���� ������ �� ������

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;
      //������Ʈ ��ġ �� ������ �� ����

    FB_GameManager gameManager;

    public void Start()
    {
        gameManager = FB_GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
          //holeSize�� �ݸ�ŭ ���� �ø�
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);
          //holeSize�� �ݸ�ŭ �Ʒ��� ����

          //top�� bottom�� Obstacle ������ �̵��ؾ� �Ѵ�.
          //�� �� localPosition�� �ƴ� position������ �̵� �� ������ �������� �̵��ϱ� ������, �Ȱ��� ��ġ�� �����ϰ� ��.

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
          //���� �������� ������ ������Ʈ �ڿ��ٰ� widthPadding��ŭ ���� �Ÿ���ŭ �̵�
          //�������� ��ġ�� ������Ʈ �ڿ� ��ġ

        placePosition.y = Random.Range(lowPosY, highPosY);
          //�ּҰ��� �ִ밪 ������ ������ ����

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision) //Ʈ���Ÿ� ��� �� ����
    {
        FB_Player player = collision.GetComponent<FB_Player>(); //�÷��̾ �´��� Ȯ���ϱ� ���� �÷��̾ ������
        if (player != null) //�÷��̾ �´ٸ�
            gameManager.AddScore(1); //���� ����
    }

}