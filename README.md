# Sparta_Meta
스파르타 메타버스 만들기 과제 (개인)

## 영상 🎥
![Sparta_Meta - MainScene - Windows, Mac, Linux - Unity 2022 3 17f1 _DX11_ 2025-05-07 10-02-22 (online-video-cutter com)](https://github.com/user-attachments/assets/182f3227-2c65-4f61-83da-1adc06255121)

## 설치 방법
`git clone https://github.com/miju99/Sparta_Meta.git`
> Unity 2022.3.17f1 이상에서 테스트됨

## 사용 방법
* 키보드/마우스 조작법
  > WASD OR ←↑→↓을 이용해 캐릭터를 이동합니다.

## 필수 기능 🛠
### ①. 캐릭터 이동 및 맵 탐색 
  * WASD나 ←↑→↓를 이용해 캐릭터 움직이기

    <details>
      <summary>[세부설명]</summary>
          * Rigidbody2D와 Collider2D 사용   
          * 맵의 가장자리에서 캐릭터가 멈추도록 설정
    </details>


### ②. 맵 설계 및 상호작용 영역
  * 간단한 맵을 설계하고, 특정 영역에서 상호작용 이벤트 발생

     <details>
      <summary>[세부설명]</summary>
    * 타일맵 또는 오브젝트로 맵 구성
    * 상호작용 가능한 오브젝트 배치
    * 특정 영역에 진입하면 이벤트 트리거
    </details>

### ③. 미니 게임 실행
  * 특정 영역에서 간단한 미니 게임을 실행

     <details>
      <summary>[세부설명]</summary>
    * 플래피버드 스타일 or 스택 스타일
    * 미니 게임 시작 전 간단한 설명 UI 표시
    * 미니 게임 종료 후 점수 반환 및 맵으로 복귀
    </details>

### ④. 점수 시스템
  * 미니 게임 점수를 기록하고 UI에 실시간 표시

     <details>
      <summary>[세부설명]</summary>
    * 점수 기록, 최고 점수 저장 및 표시
    * 미니 게임 종료 후 맵으로 돌아왔을 때 점수가 유지되도록 저장
    </details>

### ⑤. 게임 종료 및 복귀
  * 미니 게임 종료 시 맵으로 복귀 및 결과 표시

     <details>
      <summary>[세부설명]</summary>
    * 미니 게임 성공/실패 여부에 따라 메시지 표시
    * 점수를 포함한 게임 결과를 UI로 출력
    </details>

### ⑥. 카메라 추적 기능
   * 캐릭터가 이동할 때 따라오는 카메라 구현

     <details>
      <summary>[세부설명]</summary>
     * Transform 사용
     * 카메라가 특정 영역을 넘어가지 않도록 경계 설정
</details>

## 구현 👀
기능|구현 위치|입력 처리 함수
|-|-|-|
캐릭터 이동|PlayerController.cs|Input.GetAxisRaw
가장자리 이동 제한|타일맵|충돌처리
맵 설계|타일맵||
NPC|NPCTrigger.cs||
이벤트 트리거|SceneTrigger.cs|LoadScene
점수 시스템|ShowScore.cs|PlayerPrefs
카메라 추적|FollowCamera.cs|Transform

## 기술 스택
  * 게임 엔진
    > Unity(Unity 2022.3.17f1)
  * 프로그래밍 언어
    > C#
