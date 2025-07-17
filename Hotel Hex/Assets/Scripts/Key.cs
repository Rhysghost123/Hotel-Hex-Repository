using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public KeyTracker keyTracker;

    public int index;



    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance.iskeyCollected[index])
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D player)
    {
        GameObject.Destroy(gameObject);
        keyTracker.numberofKeysInLevel++;
        print(keyTracker.numberofKeysInLevel);
        GameManager.instance.iskeyCollected[index] = true;
    }
}

