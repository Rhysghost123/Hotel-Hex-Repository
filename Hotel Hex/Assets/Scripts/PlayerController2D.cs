using System.Collections;
using System.Collections.Generic;
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

        anim.SetFloat("player2DHorizontalDirection", xVelocity);
        anim.SetFloat("player2DVerticalDirection", yVelocity);

        if (horizontalInput > 0)
        {
            transform.localScale = transform.localScale;
        } else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        rb.velocity = new Vector2(xVelocity, yVelocity);

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, ground);
    }





}
