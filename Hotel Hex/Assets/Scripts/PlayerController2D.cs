using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    Rigidbody2D rb;

    public float moveSpeed = 5f;

    public Transform groundChecker;
    public LayerMask ground;
    public float groundCheckerRadius = .2f;

    public float jumpVelocity = 5f;
    public float maxFallSpeed = -15f;

    Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float xVelocity = horizontalInput * moveSpeed;
        float yVelocity = rb.velocity.y;

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = jumpVelocity;
            anim.Play("PlayerJump2D");
        }
        else if (yVelocity <= maxFallSpeed)
        {
            yVelocity = maxFallSpeed;
        }

        anim.SetFloat("player2DHorizontalDirection", Math.Abs(xVelocity));
        anim.SetFloat("player2DVerticalDirection", yVelocity);


        //make it so the jump animation only plays when the player presses jump
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("pressedJump", true);
        }
        else
        {
            anim.SetBool("pressedJump", false);
        }
        anim.SetBool("isGrounded", IsGrounded());

        if (horizontalInput > 0)
        {
            transform.localScale = new UnityEngine.Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new UnityEngine.Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        rb.velocity = new UnityEngine.Vector2(xVelocity, yVelocity);

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, ground);
    }





}
