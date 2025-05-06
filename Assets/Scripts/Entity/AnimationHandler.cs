using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
      //private : 오직 같은 클래스에서만 사용 가능
      //static : 클래스 자체에 속한 변수로, 클래스 이름을 통해 직접 접근 가능
      //readonly : 해당 변수는 초기화 이후 값을 변경할 수 없음.
      //IsMoving : IsMove를 해시 값으로 바꾼 결과가 저장됨.
      //Animator.StringToHash() : 문자열(파라미터 이름)을 Hash값으로 변환하는 함수로,
      //여기서는 IsMove라는 문자열을 Hash값으로 변환해 애니메이터 파라미터를 빠르게 찾기 위해 사용.

    protected Animator animator;
      //Animator타입을 가진 animator 변수
      //Animator 컴포넌트를 사용하여 애니메이션 관련 작업 처리

    protected virtual void Awake()
      //protected : 자기 자신/자식 클래스에서만 접근 가능
      //virtual : 오버라이딩(재정의) 가능 허용
    {
        animator = GetComponentInChildren<Animator>();
          //GetComponentInChildren<Animator>() : 현재 게임오브젝트와 자식 오브젝트에서 Animator 타입의 컴포넌트를 찾는 메서드
          //
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
          //magnitude : Vector2 객체의 길이를 계산하는 속성
          //magnitude가 0.5보다 크면 true, 작으면 false를 반환한다!
          //true/false값을 통해 애니메이션 상태를 설정할 수 있다.
    }

}
