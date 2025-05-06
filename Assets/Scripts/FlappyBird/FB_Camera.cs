using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Camera : MonoBehaviour
{
    public Transform target; //�÷��̾�
    float offsetX;

    void Start()
    {
        if (target == null) //Ÿ���� ������
            return; //����!

        offsetX = transform.position.x - target.position.x;
        //ī�޶��� X���� Ÿ���� X�� �����ν� ��ġ ����(�Ÿ�)�� ����
        // => ī�޶� Ÿ�Ϻ��� x������ ���̰���ŭ �ִٴ� ��
        // ���̰��� ����� ������(+), ������ ����(-), ���� ��ġ��� 0
    }

    void Update()
    {
        if (target == null) //Ÿ���� ������
            return; //����!

        Vector3 pos = transform.position; //ī�޶��� ��ġ ������ pos�� ����
        pos.x = target.position.x + offsetX; //ĳ���͸� ���󰡴µ�,
                                             //ĳ���� ��ġ�� �ƴ�, offsetX��ŭ ������ ���·� �̵�.
                                             //y�� z�� �״�� �ΰ�, pos�� x���� ���� ����
        transform.position = pos; //������ pos�� ī�޶��� ��ġ�� ����(x���� ����)
    }
}
