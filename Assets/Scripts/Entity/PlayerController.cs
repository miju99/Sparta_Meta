using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera mainCamera;
      //new : �θ�Ŭ������ ���� �̸��� ����� �ִ� ��� ����ٴ� �ǹ̸� ��Ȯ�� �ϱ� ���� ���
      //Unity�� ���� ī�޶� ����
      //BaseController�� camera�� ���µ� �� new�� ��� �ϳ���? ����� ��� ��ϴ�.
      // => ��� ���� �����ص� ��� ����!
      // *����* : camera�� �̹� Unity���� ���ǰ� �ֱ� ������ mainCamera�� �����ϸ� �� ���!

    protected override void Start()
    {
        base.Start(); //�θ� Ŭ������ Start() ȣ��
        mainCamera = Camera.main;
    }


    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //Ű������ ���� �Է�
        float vertial = Input.GetAxisRaw("Vertical"); //Ű������ ���� �Է�

          //GetAxisRaw : 1, 0, -1�� ��� ��ȯ

        movementDirection = new Vector2(horizontal, vertial).normalized;
          //nomalized : ���⸸ ���

        animationHandler.Move(movementDirection);
          //animationHandler�� �ִϸ��̼� ó��

        Vector2 mousePosition = Input.mousePosition; //���콺 ��ġ(��ǥ) ��������
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePosition);
          //���콺�� ��ǥ�� ���� ��ǥ�� ��ȯ
        lookDirection = (worldPos - (Vector2)transform.position);
          //���콺 ��ǥ���� ĳ������ ��ǥ�� �����ν� ĳ���Ͱ� �ٶ���� �� ������ ����.

        if (lookDirection.magnitude < 0.9f)
            //lookDirection : ĳ������ ��ġ�� ���콺 ��ġ�� ���ϴ� ���� ����
            //���콺�� ��ġ�� ĳ������ �ٷ� ��ó�̸�
        {
            lookDirection = Vector2.zero;
            //�ƹ� ���⵵ �ٶ��� �ʴ´�! �� ����
        }
        else
        {
            lookDirection = lookDirection.normalized;
              //nomarlized : ���͸� ����ȭ�Ͽ� ������ �����ϵ� ����(magnitude)�� 1�� ����.
              //���⸸ �ʿ��ϱ� ������ �ӵ��� �����ϰ� �����ϱ� ���� ���
        }

        //magnitude : ������ ����(ũ��)�� ��Ÿ���� �Ӽ�.
    }
}
