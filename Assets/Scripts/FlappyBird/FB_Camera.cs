using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Camera : MonoBehaviour
{
    public Transform target; //플레이어
    float offsetX;

    void Start()
    {
        if (target == null) //타겟이 없으면
            return; //종료!

        offsetX = transform.position.x - target.position.x;
        //카메라의 X에서 타겟의 X를 뺌으로써 위치 차이(거리)를 저장
        // => 카메라가 타켓보다 x축으로 차이값만큼 있다는 뜻
        // 차이값이 양수면 오른쪽(+), 음수면 왼쪽(-), 같은 위치라면 0
    }

    void Update()
    {
        if (target == null) //타겟이 없으면
            return; //종료!

        Vector3 pos = transform.position; //카메라의 위치 가져와 pos에 복사
        pos.x = target.position.x + offsetX; //캐릭터를 따라가는데,
                                             //캐릭터 위치가 아닌, offsetX만큼 떨어진 상태로 이동.
                                             //y와 z는 그대로 두고, pos의 x값만 새로 설정
        transform.position = pos; //수정한 pos를 카메라의 위치로 넣음(x값만 변경)
    }
}
