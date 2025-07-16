using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController2D : MonoBehaviour
{

    Rigidbody2D rb;

    public float moveSpeed = 5f;

    public Transform groundChecker;
    public LayerMask ground;
    public float groundCheckerRadius = .2f;

    public float jumpVelocity = 5f;
    public float maxFallSpeed = -15f;

    //variables needed for the dash
    public float dashStrength = 40f;
    float normalGravity;
    bool isDashing;
    bool canDash;

    Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        normalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float xVelocity = horizontalInput * moveSpeed;
        float yVelocity = rb.velocity.y;
        UnityEngine.Vector2 dir = new UnityEngine.Vector2(horizontalInput, Input.GetAxisRaw("Vertical"));

        if (IsGrounded())
        {
            canDash = true;
        }

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            if (dir == new UnityEngine.Vector2(0, 0))
            {
                dir = new UnityEngine.Vector2(transform.localScale.x, Input.GetAxisRaw("Vertical"));
                StartCoroutine(Dash(dir, dashStrength));
            }
            else
            {
                StartCoroutine(Dash(dir, dashStrength));
                canDash = false;
            }
            
        }
        else if (!isDashing)
        {
            rb.velocity = new UnityEngine.Vector2(xVelocity, yVelocity);
        }

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, ground);
    }

    IEnumerator Dash(UnityEngine.Vector2 direction, float magnitude)
    {
        anim.Play("PlayerDash2D");
        isDashing = true;
        rb.gravityScale = 0;
        UnityEngine.Vector2 originalVelocity = rb.velocity;
        rb.velocity = direction * magnitude;
        yield return new WaitForSeconds(.2f);
        rb.velocity = direction * magnitude/2;
        rb.gravityScale = normalGravity;
        isDashing = false;
    }





}
