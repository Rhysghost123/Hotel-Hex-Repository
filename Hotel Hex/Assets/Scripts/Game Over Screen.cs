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
        GameManager.instance.iskeyCollected = new bool[7];
        print("a1");
        for (int index = 0; index < GameManager.instance.iskeyAttained.Length; index++)
                {
                   GameManager.instance.iskeyCollected[index] = GameManager.instance.iskeyAttained[index];
                }

        for (int index = 0; index < GameManager.instance.iskeyAttained.Length; index++)
        {
            if (GameManager.instance.iskeyCollected[index] == true && GameManager.instance.iskeyAttained[index] == false)
            {
                print("a2");
                GameManager.instance.iskeyCollected[index] = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
