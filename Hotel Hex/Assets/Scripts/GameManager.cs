using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int worldScore = 0;




    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {

            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //differentiate between different scenes the gamemanager is in


    }
    public string Mainroom = "Main room";
    public string mainmenu = "Main menu";




    //we do not need to define a load scene function when it already exists.

    // Update is called once per frame
    // public void LoadScene(string name)
    // {
    //    SceneManager.LoadScene(name);
    // }





}
