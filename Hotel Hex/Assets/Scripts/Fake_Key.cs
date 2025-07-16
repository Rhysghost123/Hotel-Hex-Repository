using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class Mimic : MonoBehaviour
{
    public GameObject player;
    UnityEngine.Vector2 playerPosition;
    UnityEngine.Vector2 objectPosition;
    public float interactRng;
    public float speed = 5;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            playerPosition = player.GetComponent<Transform>().position; // gets player's vector2 position
            objectPosition = GetComponent<Transform>().position; //Gets Object position

            float xCloseness = Math.Abs(playerPosition.x - objectPosition.x); //
            float yCloseness = Math.Abs(playerPosition.y - objectPosition.y);

            if (xCloseness < interactRng && yCloseness < interactRng)
            {
                Vector2 dir = playerPosition - objectPosition;

                rb.velocity = dir.normalized * speed;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
