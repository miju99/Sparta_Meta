using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
      // Rigidbodt2D 컴포넌트를 저장할 변수, _rigidbody

    [SerializeField] private SpriteRenderer characterRenderer;
      //[SerializeField] : private 변수라도 Unity 인스펙터에서 값을 할당할 수 있도록 함.
      //변수를 *직렬화* 하여 인스펙터에 노출되도록 만들어주는 기능 -> private로 보호는 하되, 에디터에서 값 조절이 가능해진다.
      //SpriteRenderer : 2D게임에서 스프라이트를 화면에 렌더링하는 컴포넌트

    protected Vector2 movementDirection = Vector2.zero;
     //Vector2.zero 는 (0,0)을 의미하므로 이동하지 않는다.

    public Vector2 MovementDirection { get { return movementDirection; } }
     //MovementDirection : movementDirecton을 외부에서 읽을 수 있게 해주며, 호출 시 movementDirection의 값을 얻을 수 있다.

    protected Vector2 lookDirection = Vector2.zero;

    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
     //knockbackDuration : 넉백이 지속되는 시간 선언

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //_rigidbodt 초기화
    }

    protected virtual void Start()
    {
        animationHandler = GetComponent<AnimationHandler>(); //AnimationHandler 초기화
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate() //특수한 목적을 가진 콜백 메서드
      //고정된 시간 간격으로 호출 (항상 일정한 시간 간격!)
    {
        Movment(movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {
        //빈 메서드로 선언해 두는 이유는,
        //1. 상속받은 클래스에서 오버라이드하여 동작을 커스터마이즈 할 수 있도록 하며,
        //2. 이를 통해 유연성, 확장성, 유지보수성을 높일 수 있다.
    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 5;
          //direction에 속도값 5를 곱함! -> 이동 속도
        if (knockbackDuration > 0.0f) //넉백이 있다면!
        {
            direction *= 0.2f; // 넉백 시 속도 저하
            direction += knockback; //이동 방향에 넉백을 줌으로써 추가적인 이동 발생!
        }

        _rigidbody.velocity = direction; //Rigidbodty의 velocity를 이용한 이동
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
          //Mathf.Atan2 : 두 점 사이의 각도 계산 / (x, y)좌표로 정의된 벡터에서의 각도를 구한다!
          //direction.y-x : 캐릭터가 바라보는 방향을 나타내는 벡터 y와 x값
          // -> 캐릭터가 바라보는 방향의 각도를 구하게 된다!

        bool isLeft = Mathf.Abs(rotZ) > 90f;
          //roZ -> Atan2로 구한 각도!
          //Mathf.Abs(rotZ) : 각도의 절댓값을 구한다.
          //90도는 오른쪽을 바라본다. 즉 절댓값이 90보다 크면 왼쪽을 바라보는 것.
          //isLeft 가 90보다 크면, 왼쪽을 바라보고 true가 된다!

        characterRenderer.flipX = isLeft;
          //flipX는 스프라이트의 좌우 반전을 설정!
          //true인 경우 왼쪽, false인 경우 오른쪽을 향하게 된다.
          //즉 isLeft가 true일 때, 왼쪽을 바라보면 스프라이트가 반전되고, false일 때 오른쪽을 보면 반전되지 않음.
    }

    /*public void ApplyKnockback(Transform other, float power, float duration)
      //transform other : 충돌한 대상의 위치
      //power : 넉백의 파워
      //duration : 넉백 지속 시간
    {
        knockbackDuration = duration;
          //넉백 지속 시간을 저장할 변수 KnockbackDuration
        knockback = -(other.position - transform.position).normalized * power;
          //other.position : 충돌한 대상의 위치!
          //transform.position : 객체의 위치!
          //적의 위치 - 플레이어 위치 : 둘 사이의 벡터
          // -(other.position - transform.position) : 위의 벡터를 반대방향으로 바꿈 -> 
    }*/
}
