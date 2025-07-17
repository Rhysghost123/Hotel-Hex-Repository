using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DeathBarrierScript : MonoBehaviour
{


    void Start()
    {
    
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision detected");
        if (collision.CompareTag("Player"))
        {
            Destroy(collision);
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
        }
    }




}
