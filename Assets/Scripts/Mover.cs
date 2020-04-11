using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Animator animator;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var deltaY = Input.GetAxis("Vertical") * speed;


        myRigidBody.velocity = new Vector2(deltaX, deltaY);

        if (Math.Abs(deltaX) + Math.Abs(deltaY)>0)
        {
            TriggerWalk(deltaX, deltaY);
        }
        else
        {
            TriggerIdle();
        }

        // TriggerStateAnimation(deltaX, deltaY);

    }

    private void TriggerIdle()
    {
        animator.SetBool("isWalking", false);
    }
    private void TriggerWalk(float deltaX, float deltaY)
    {
        animator.SetBool("isWalking", true);
        animator.SetFloat("xInput", deltaX);
        animator.SetFloat("yInput", deltaY);
    }

}
