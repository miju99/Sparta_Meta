using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FB_Player : MonoBehaviour
{
    Animator animator = null; //�ʱ�ȭ
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f; //����
    public float forwardSpeed = 3f; //���� �̵�
    public bool isDead = false;
    float deathCooldown = 0f; //�浹 �� ���� �ð� �� ����

    bool isFlap = false; //������ �ߴ��� �� �ߴ���

    FB_GameManager gameManager = null;

    public Button restartButton;
    public Button returnMenuButton;

    float inputDelayTime = 0.1f;

    void Start()
    {
        gameManager = FB_GameManager.Instance; //�ʱ�ȭ�� Awake���� ���ְ� �ֱ� ������ Start���� ����!

        animator = transform.GetComponentInChildren<Animator>();
        //GetComponentInChildren : ���� ������Ʈ(�ڽ�)���� �˻��� ������.
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        //GetComponent : �ش� ��ũ��Ʈ�� �پ��ִ� ������Ʈ���� ã���ִ� ������Ʈ�� �ִ���, �ִٸ� �װ� ��ȯ���ִ� ����� ������ �ִ�.

        if (animator == null) //����ó��
        {
            Debug.LogError("�ִϸ����͸� ã�� �� �����.");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("RigidBodt�� ã�� �� �����.");
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
            //�����̽��� �Ǵ� ���콺 ���� ��ư�� �̿��� ������ true���� ����! => ���� ����
            // +) GetMouseButtonDown�� ��ȣ - 0 : ���� / 1 : ���� / 2 : �� / 3 : �ڷ� ���� / 4 : ������ ���� => ����Ʈ�������� ��ġ ��ɵ� ����
        {
            isFlap = true; //jump�� �ߴ�!
        }

    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
          //velocity : ���ӵ�
          //velocity �� _rigidbody�� ������ �ִ� ���ӵ�(���������� �ް� �ִ� ��)�� ������ ��.
        velocity.x = forwardSpeed;
          //���ӵ��� ��� �Ȱ��� ������ �־��ֱ� ������ �Ȱ��� �ӵ��� �̵�

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;
          //_rigidbody.velocity�� ���� ������ �� ������, ������ ���� ��ȭ�� �� �ƴϱ� ������(Vector3�� Struct�̱� ����!)
          //�ٽ� �־��ִ� �۾��� �ʿ��ϴ�.

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
          //Clamp : ���� ������ �д�. Ư���� ���� min(���⽺�� -90)�� max(90)�� ����!
          //�̶��� ������ _rigidbody.velocity.y * 10f(���� �۱⶧���� ������) -> �� ���� �ٴ����� �������� ��, �ö󰡰� �ִ��� ����
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
          //rotation�� Quaternion(����� ��) ����ϹǷ� Euler(degree | 180��, 360���� �������� �ϴ� ����)�� ���
          //x,y,z������ �󸶸�ŭ ȸ���� ��ų �� ���Ѵ�.

          //transform�� gameObject�Ӽ��� ���� ����ؼ� �ٷ� ����� �� �ֵ��� ����Ǿ� ����.
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