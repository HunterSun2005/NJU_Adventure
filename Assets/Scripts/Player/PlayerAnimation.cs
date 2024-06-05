using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.1 || Mathf.Abs(rb.velocity.y) > 0.1)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (rb.velocity.x > 0.1){
            animator.SetFloat("InputX", 1);
        }
        else if (rb.velocity.x < -0.1)
        {
            animator.SetFloat("InputX", -1);
        }
        else
        {
            animator.SetFloat("InputX", 0);
        }

        if (rb.velocity.y > 0.1)
        {
            animator.SetFloat("InputY", 1);
        }
        else if (rb.velocity.y < -0.1)
        {
            animator.SetFloat("InputY", -1);
        }
        else
        {
            animator.SetFloat("InputY", 0);
        }
    }
}
