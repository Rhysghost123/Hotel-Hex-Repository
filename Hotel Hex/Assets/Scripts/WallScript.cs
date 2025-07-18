using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{

    public float wallSpeed = 1f;



    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player") && (SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Tutorial"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new UnityEngine.Vector3(wallSpeed, 0, 0) * Time.deltaTime);



    }
}
