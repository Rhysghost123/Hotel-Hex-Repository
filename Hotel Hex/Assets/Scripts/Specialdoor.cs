using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialdoor : MonoBehaviour
{
    public float keyCheck;
    public bool dooropen = false;
    public GameObject key;
    public int amountofkeys = 3;

    // Update is called once per frame
    void Update()
    {
        if(keyCheck == amountofkeys)
        {
            dooropen = true;
            print("the Door is open");
        }
        if(dooropen == true)
        {

        }
    }
}
