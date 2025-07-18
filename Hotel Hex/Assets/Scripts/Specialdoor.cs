using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Specialdoor : MonoBehaviour
{
    public int keysNeeded = 7;
    public bool dooropen = false;
    int amountofkeys;

    public GameObject player;
    Vector2 playerPosition;
    Vector2 objectPosition;
    public float interactRng = 2;

    public GameObject button;
    public GameObject buttonInstance;
    public Camera cam;
    public Vector3 buttonOffset = new UnityEngine.Vector3(.5f, .5f, 0);

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position; // gets player's vector2 position
        objectPosition = GetComponent<Transform>().position; //Gets Object position

        float xCloseness = Math.Abs(playerPosition.x - objectPosition.x); //
        float yCloseness = Math.Abs(playerPosition.y - objectPosition.y);

        if (amountofkeys == keysNeeded)
        {
            dooropen = true;
            print("Congratulations! You have attained all the keys!");
        }
        if (dooropen && xCloseness < interactRng && yCloseness < interactRng && Input.GetKeyDown(KeyCode.E))
        {
            print("You escaped");
            //SceneManager.loadScene("End");
            SceneManager.LoadScene("WIN SCREEN");
        }
    }

    void Start()
    {
        amountofkeys = GameManager.instance.worldScore;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && amountofkeys == keysNeeded)
        {
            buttonInstance = Instantiate(button, transform.position, transform.rotation);
            buttonInstance.transform.GetChild(0).transform.position = cam.WorldToScreenPoint(transform.position) + buttonOffset;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && amountofkeys == keysNeeded)
        {
            Destroy(buttonInstance);
        }
    }
}
