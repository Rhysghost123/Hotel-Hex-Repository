using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyTracker : MonoBehaviour
{



    TMPro.TMP_Text texthandler;
    int totalnumberOfKeyObjects;
    int keysAlreadyCollected;
   public int numberofKeysInLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        texthandler = GetComponent<TMPro.TMP_Text>();
        totalnumberOfKeyObjects = GameObject.FindObjectsOfType(typeof(Key)).Length;
        keysAlreadyCollected = GameManager.instance.leveloneScore;
    }

    // Update is called once per frame
    void Update()
    {
        texthandler.text = (numberofKeysInLevel + keysAlreadyCollected).ToString() + "/" + totalnumberOfKeyObjects.ToString();
    }
}
