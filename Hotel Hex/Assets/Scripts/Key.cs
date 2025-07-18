using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public KeyTracker keyTracker;

    public int index;



    public TMPro.TMP_Text tutorialRUN;
    public GameObject wallSpawner;



    // Start is called before the first frame update
    void Awake()
    {

        if (index != -1)
        {
         if (GameManager.instance.iskeyAttained[index])
        {
            Destroy(gameObject);
        }
       }
       
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D player)
    {

        if (index == -1)
        {
            GameObject.Destroy(gameObject);
            tutorialRUN.gameObject.SetActive(true);
            //play roar
            wallSpawner.SetActive(true);

        }
        else
        {
            GameObject.Destroy(gameObject);
            keyTracker.numberofKeysInLevel++;
            print(keyTracker.numberofKeysInLevel);
            print("a5");
            GameManager.instance.iskeyCollected[index] = true;
            GameManager.instance.iskeyAttained[index] = false;
        }
    }
}

