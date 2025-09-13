using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool IsRuning = animator.GetBool("IsRuning");
        bool forwardPressed = Input.GetKey(KeyCode.R);

        if (!IsRuning  && forwardPressed)
        {
            animator.SetBool("IsRuning", true);
        }

        if (IsRuning  && !forwardPressed)
        {
            animator.SetBool("IsRuning", false);
        }
    }
}