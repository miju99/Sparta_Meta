using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        offsetX = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = new Vector3(target.position.x +  offsetX, target.position.y + offsetY, transform.position.z);

        transform.position = pos;
    }
}
