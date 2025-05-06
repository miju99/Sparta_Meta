using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FB_Player : MonoBehaviour
{
    Animator animator = null; //초기화
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f; //점프
    public float forwardSpeed = 3f; //정면 이동
    public bool isDead = false;
    float deathCooldown = 0f; //충돌 후 일정 시간 후 죽음

    bool isFlap = false; //점프를 했는지 안 했는지

    FB_GameManager gameManager = null;

    public Button restartButton;
    public Button returnMenuButton;

    float inputDelayTime = 0.1f;

    void Start()
    {
        gameManager = FB_GameManager.Instance; //초기화를 Awake에서 해주고 있기 때문에 Start에서 접근!

        animator = transform.GetComponentInChildren<Animator>();
        //GetComponentInChildren : 하위 오브젝트(자식)까지 검색을 진행함.
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        //GetComponent : 해당 스크립트가 붙어있는 오브젝트한테 찾고있는 컴포넌트가 있는지, 있다면 그걸 반환해주는 기능을 가지고 있다.

        if (animator == null) //예외처리
        {
            Debug.LogError("애니메이터를 찾을 수 없어요.");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("RigidBodt를 찾을 수 없어요.");
        }

        restartButton.onClick.AddListener(gameManager.RestartGame);
        returnMenuButton.onClick.AddListener(gameManager.ReturnMenu);
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown > 0)
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        if (inputDelayTime > 0f)
        {
            inputDelayTime -= Time.deltaTime;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            //스페이스바 또는 마우스 왼쪽 버튼을 이용할 때마다 true값이 나감! => 게임 진행
            // +) GetMouseButtonDown의 번호 - 0 : 왼쪽 / 1 : 우측 / 2 : 휠 / 3 : 뒤로 가기 / 4 : 앞으로 가기 => 스마트폰에서의 터치 기능도 포함
        {
            isFlap = true; //jump를 했다!
        }

    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
          //velocity : 가속도
          //velocity 는 _rigidbody가 가지고 있는 가속도(물리적으로 받고 있는 힘)를 가지고 옴.
        velocity.x = forwardSpeed;
          //가속도를 계속 똑같은 값으로 넣어주기 때문에 똑같은 속도로 이동

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;
          //_rigidbody.velocity의 값을 가지고 온 것이지, 실제로 값이 변화한 게 아니기 때문에(Vector3는 Struct이기 때문!)
          //다시 넣어주는 작업이 필요하다.

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
          //Clamp : 값에 제한을 둔다. 특정한 값을 min(여기스는 -90)과 max(90)로 구분!
          //이때의 기준이 _rigidbody.velocity.y * 10f(값이 작기때문에 곱해줌) -> 이 값이 바닥으로 떨어지는 지, 올라가고 있는지 구분
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
          //rotation은 Quaternion(사원수 값) 사용하므로 Euler(degree | 180도, 360도를 기준으로 하는 각도)를 사용
          //x,y,z축으로 얼마만큼 회전을 시킬 지 정한다.

          //transform과 gameObject속성은 자주 사용해서 바로 사용할 수 있도록 내장되어 있음.
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        gameManager.GameOver();
    }
}