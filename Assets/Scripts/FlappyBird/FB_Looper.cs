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
          //GameObject.FindObjectsOfType<FB_Obstacle>() : 씬에 있는 모든 FB_Obstacle 객체를 찾아 배열로 반환
          //FindObjectOfType : <T>타입의 모든 객체를 찾아 배열로 반환

        obstacleLastPosition = obstacles[0].transform.position;
        //배열의 첫 번째 객체의 월드 위치 반환
        //obstacleLastPosition : 첫 번째 객체의 위치 저장

        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
              //반복문을 돌면서 위치를 랜덤으로 설정
              //Obstacle이 배치가 되면 배치한 위치를 받아 다음 Obstacle이 배치될 곳 전달.
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) //충돌 처리되면 모두 뒤로 보냄.
        //trigger는 충돌에 대한 정보는 줄 수 없고, 충돌체에 대한 정보만 준다!
    {
        //Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = collision.bounds.size.x;
              //각각의 오브젝트들의 사이즈 가져오기
              //vollision.bounds : collider의 경계를 나타냄 = 크기를 포함하고 있다!
              //x의 사이즈를 구하기 때문에 가로의 크기를 구하게 됨.

            Vector3 pos = collision.transform.position;
              //충돌한 오브젝트의 위치 가져오기

            pos.x += widthOfBgObject * numBgCount;
              //가로 사이즈 * 개수
            collision.transform.position = pos;
            return; //BackGround로 처리를 했기 때문에 (Obstacle이 될 수 없음!) 더이상 동작하지 않도록
        }

        FB_Obstacle obstacle = collision.GetComponent<FB_Obstacle>();
          //충돌체에서 obstacle이 있는 지 확인
        if (obstacle) //obstacle이 null이 아니라면
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
              //위와 같이 진행!
        }
    }
}