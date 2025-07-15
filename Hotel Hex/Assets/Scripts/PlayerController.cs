using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

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

        //this is the standard movement code
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        UnityEngine.Vector2 rigidbodyDirection = new UnityEngine.Vector2(horizontalInput, verticalInput).normalized;

        //quickly make it so the animator understands when the player is moving in what direction
        if (Time.timeScale != 0)
        {
            anim.SetFloat("playerVerticalDirection", verticalInput);
            anim.SetFloat("playerHorizontalDirection", horizontalInput);
        }
        rb.velocity = rigidbodyDirection * moveSpeed;
    }
    public void OnTriggerEnter2D(Collider2D key)
    {
        GameObject.Destroy(key.gameObject);
    }
}
