using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
      // Rigidbodt2D ������Ʈ�� ������ ����, _rigidbody

    [SerializeField] private SpriteRenderer characterRenderer;
      //[SerializeField] : private ������ Unity �ν����Ϳ��� ���� �Ҵ��� �� �ֵ��� ��.
      //������ *����ȭ* �Ͽ� �ν����Ϳ� ����ǵ��� ������ִ� ��� -> private�� ��ȣ�� �ϵ�, �����Ϳ��� �� ������ ����������.
      //SpriteRenderer : 2D���ӿ��� ��������Ʈ�� ȭ�鿡 �������ϴ� ������Ʈ

    protected Vector2 movementDirection = Vector2.zero;
     //Vector2.zero �� (0,0)�� �ǹ��ϹǷ� �̵����� �ʴ´�.

    public Vector2 MovementDirection { get { return movementDirection; } }
     //MovementDirection : movementDirecton�� �ܺο��� ���� �� �ְ� ���ָ�, ȣ�� �� movementDirection�� ���� ���� �� �ִ�.

    protected Vector2 lookDirection = Vector2.zero;

    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
     //knockbackDuration : �˹��� ���ӵǴ� �ð� ����

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //_rigidbodt �ʱ�ȭ
    }

    protected virtual void Start()
    {
        animationHandler = GetComponent<AnimationHandler>(); //AnimationHandler �ʱ�ȭ
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate() //Ư���� ������ ���� �ݹ� �޼���
      //������ �ð� �������� ȣ�� (�׻� ������ �ð� ����!)
    {
        Movment(movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {
        //�� �޼���� ������ �δ� ������,
        //1. ��ӹ��� Ŭ�������� �������̵��Ͽ� ������ Ŀ���͸����� �� �� �ֵ��� �ϸ�,
        //2. �̸� ���� ������, Ȯ�强, ������������ ���� �� �ִ�.
    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 5;
          //direction�� �ӵ��� 5�� ����! -> �̵� �ӵ�
        if (knockbackDuration > 0.0f) //�˹��� �ִٸ�!
        {
            direction *= 0.2f; // �˹� �� �ӵ� ����
            direction += knockback; //�̵� ���⿡ �˹��� �����ν� �߰����� �̵� �߻�!
        }

        _rigidbody.velocity = direction; //Rigidbodty�� velocity�� �̿��� �̵�
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
          //Mathf.Atan2 : �� �� ������ ���� ��� / (x, y)��ǥ�� ���ǵ� ���Ϳ����� ������ ���Ѵ�!
          //direction.y-x : ĳ���Ͱ� �ٶ󺸴� ������ ��Ÿ���� ���� y�� x��
          // -> ĳ���Ͱ� �ٶ󺸴� ������ ������ ���ϰ� �ȴ�!

        bool isLeft = Mathf.Abs(rotZ) > 90f;
          //roZ -> Atan2�� ���� ����!
          //Mathf.Abs(rotZ) : ������ ������ ���Ѵ�.
          //90���� �������� �ٶ󺻴�. �� ������ 90���� ũ�� ������ �ٶ󺸴� ��.
          //isLeft �� 90���� ũ��, ������ �ٶ󺸰� true�� �ȴ�!

        characterRenderer.flipX = isLeft;
          //flipX�� ��������Ʈ�� �¿� ������ ����!
          //true�� ��� ����, false�� ��� �������� ���ϰ� �ȴ�.
          //�� isLeft�� true�� ��, ������ �ٶ󺸸� ��������Ʈ�� �����ǰ�, false�� �� �������� ���� �������� ����.
    }

    /*public void ApplyKnockback(Transform other, float power, float duration)
      //transform other : �浹�� ����� ��ġ
      //power : �˹��� �Ŀ�
      //duration : �˹� ���� �ð�
    {
        knockbackDuration = duration;
          //�˹� ���� �ð��� ������ ���� KnockbackDuration
        knockback = -(other.position - transform.position).normalized * power;
          //other.position : �浹�� ����� ��ġ!
          //transform.position : ��ü�� ��ġ!
          //���� ��ġ - �÷��̾� ��ġ : �� ������ ����
          // -(other.position - transform.position) : ���� ���͸� �ݴ�������� �ٲ� -> 
    }*/
}
