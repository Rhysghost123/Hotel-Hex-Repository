using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject button; //here's the actual prefab of the button we will be instantiating

    public Camera cam;
    public GameObject buttonInstance; //here is the variable to store the instance of the prefab
    public UnityEngine.Vector3 buttonOffset = new UnityEngine.Vector3(.5f, .5f, 0);
    public GameObject player; //yep, we need a reference to the player

    UnityEngine.Vector2 playerPosition;
    UnityEngine.Vector2 objectPosition;
    public float interactRng; //the range from which the button prompt will appear

    public int doorNumber = 0; //this is for doors only--it'll make it so that door 1 goes to lvl 1 and so forth. If the object is an escape door then it's 0

    public KeyTracker keyTracker;

    public bool isTutorialdoor;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("player went near the door!");

        if (collision.CompareTag("Player"))
        {
            buttonInstance = Instantiate(button, transform.position, transform.rotation);
            buttonInstance.transform.GetChild(0).transform.position = cam.WorldToScreenPoint(transform.position) + buttonOffset;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(buttonInstance);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position; // gets player's vector2 position
        objectPosition = GetComponent<Transform>().position; //Gets Object position

        float xCloseness = Math.Abs(playerPosition.x - objectPosition.x); //
        float yCloseness = Math.Abs(playerPosition.y - objectPosition.y);

        if (xCloseness < interactRng && yCloseness < interactRng && Input.GetKeyDown(KeyCode.E) && doorNumber > 0)
        {
            SceneManager.LoadScene("Level " + doorNumber.ToString());
        }
        else if (xCloseness < interactRng && yCloseness < interactRng && Input.GetKeyDown(KeyCode.E) && doorNumber == 0)
        {

            if (isTutorialdoor)
            {
                SceneManager.LoadScene("HUB Scene");
            }
            else
            {
                SceneManager.LoadScene("HUB Scene");
            GameManager.instance.worldScore += keyTracker.numberofKeysInLevel;
            }

            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                GameManager.instance.leveloneScore += keyTracker.numberofKeysInLevel;
            }
            else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                GameManager.instance.leveltwoScore += keyTracker.numberofKeysInLevel;
            }

            print(GameManager.instance.worldScore);
        }
    }
}
