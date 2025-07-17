using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public float restartbutton;

    // Start is called before the first frame update
    public void RestartButton()
    {
        SceneManager.LoadScene("Hub Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
