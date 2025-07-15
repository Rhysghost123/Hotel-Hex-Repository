using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 5f;
    bool canJump = true;

    public Transform groundChecker;
    public LayerMask ground;
    public float groundCheckerRadius = .2f;

    public float jumpVelocity = 5f;
    public float maxFallSpeed = -15f;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        }
        else if (yVelocity <= maxFallSpeed)
        {
            yVelocity = maxFallSpeed;
        }

        rb.velocity = new Vector2(xVelocity, yVelocity);

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, ground);
    }





}
