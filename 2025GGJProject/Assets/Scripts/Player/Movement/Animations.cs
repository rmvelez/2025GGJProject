using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    PlayerMovement movement;
    Rigidbody2D rb;



    [SerializeField] float attackDuration = 2;
    [SerializeField] float blockDuration = 2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKey(KeyCode.L))
        {
            StartCoroutine(BlockBubble());
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            StopCoroutine(BlockBubble());
        }


        IEnumerator Attack()
        {
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(attackDuration);
            animator.SetBool("isAttacking", false);
        }

        IEnumerator BlockBubble()
        {
            animator.SetBool("isBlocking", true);
            yield return new WaitForSeconds(blockDuration);
            animator.SetBool("isBlocking", false);
        }
    }
}



