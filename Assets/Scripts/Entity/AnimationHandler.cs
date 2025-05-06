using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
      //private : ���� ���� Ŭ���������� ��� ����
      //static : Ŭ���� ��ü�� ���� ������, Ŭ���� �̸��� ���� ���� ���� ����
      //readonly : �ش� ������ �ʱ�ȭ ���� ���� ������ �� ����.
      //IsMoving : IsMove�� �ؽ� ������ �ٲ� ����� �����.
      //Animator.StringToHash() : ���ڿ�(�Ķ���� �̸�)�� Hash������ ��ȯ�ϴ� �Լ���,
      //���⼭�� IsMove��� ���ڿ��� Hash������ ��ȯ�� �ִϸ����� �Ķ���͸� ������ ã�� ���� ���.

    protected Animator animator;
      //AnimatorŸ���� ���� animator ����
      //Animator ������Ʈ�� ����Ͽ� �ִϸ��̼� ���� �۾� ó��

    protected virtual void Awake()
      //protected : �ڱ� �ڽ�/�ڽ� Ŭ���������� ���� ����
      //virtual : �������̵�(������) ���� ���
    {
        animator = GetComponentInChildren<Animator>();
          //GetComponentInChildren<Animator>() : ���� ���ӿ�����Ʈ�� �ڽ� ������Ʈ���� Animator Ÿ���� ������Ʈ�� ã�� �޼���
          //
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
          //magnitude : Vector2 ��ü�� ���̸� ����ϴ� �Ӽ�
          //magnitude�� 0.5���� ũ�� true, ������ false�� ��ȯ�Ѵ�!
          //true/false���� ���� �ִϸ��̼� ���¸� ������ �� �ִ�.
    }

}
