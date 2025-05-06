using UnityEngine;
using Random = UnityEngine.Random;

public class FB_Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;
      // Obstacle이 상하로 이동할 때 얼마나 이동할 지

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;
      //top과 bottom사이에 얼마의 공간을 줄 것인지

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;
      //오브젝트 배치 시 사이의 폭 간격

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
          //holeSize의 반만큼 위로 올림
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);
          //holeSize의 반만큼 아래로 내림

          //top과 bottom은 Obstacle 내에서 이동해야 한다.
          //이 때 localPosition이 아닌 position값으로 이동 시 원점을 기준으로 이동하기 때문에, 똑같은 위치에 등장하게 됨.

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
          //제일 마지막에 놓여진 오브젝트 뒤에다가 widthPadding만큼 더한 거리만큼 이동
          //마지막에 배치된 오브젝트 뒤에 배치

        placePosition.y = Random.Range(lowPosY, highPosY);
          //최소값과 최대값 사이의 랜덤값 생성

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision) //트리거를 벗어날 때 도출
    {
        FB_Player player = collision.GetComponent<FB_Player>(); //플레이어가 맞는지 확인하기 위해 플레이어를 가져옴
        if (player != null) //플레이어가 맞다면
            gameManager.AddScore(1); //점수 증가
    }

}