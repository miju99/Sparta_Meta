using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private new Camera camera;
      //new : 부모클래스에 같은 이름의 멤버가 있는 경우 덮어쓴다는 의미를 명확히 하기 위해 사용
      //Unity의 메인 카메라 참조
      //BaseController에 camera가 없는데 왜 new를 써야 하나요? 지우면 경고가 뜹니다.


    protected override void Start()
    {
        base.Start(); //부모 클래스의 Start() 호출
        camera = Camera.main;
    }


    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //키보드의 수평 입력
        float vertial = Input.GetAxisRaw("Vertical"); //키보드의 수직 입력

          //GetAxisRaw : 1, 0, -1값 즉시 반환

        movementDirection = new Vector2(horizontal, vertial).normalized;
          //nomalized : 방향만 사용

        animationHandler.Move(movementDirection);
          //animationHandler에 애니메이션 처리

        Vector2 mousePosition = Input.mousePosition; //마우스 위치(좌표) 가져오기
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
          //마우스의 좌표를 월드 좌표로 변환
        lookDirection = (worldPos - (Vector2)transform.position);
          //마우스 좌표에서 캐릭터의 좌표를 뺌으로써 캐릭터가 바라봐야 할 방향을 구함.

        if (lookDirection.magnitude < 0.9f)
            //lookDirection : 캐릭터의 위치를 마우스 위치로 향하는 방향 벡터
            //마우스의 위치가 캐릭터의 바로 근처이면
        {
            lookDirection = Vector2.zero;
            //아무 방향도 바라보지 않는다! 의 상태
        }
        else
        {
            lookDirection = lookDirection.normalized;
              //nomarlized : 벡터를 정규화하여 방향은 유지하되 길이(magnitude)는 1로 만듦.
              //방향만 필요하기 때문에 속도를 일정하게 유지하기 위해 사용
        }

        //magnitude : 벡터의 길이(크기)를 나타내는 속성.
    }
}
