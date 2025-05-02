using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyUIAnimation : MonoBehaviour
{
    private static bool isShow = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (isShow)
        {
            gameObject.SetActive(false);
        }
        else
        {
            isShow = true;
            animator.Play("FadeOut");
        }
    }

}
