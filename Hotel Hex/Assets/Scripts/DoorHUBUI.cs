using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHUBUI : MonoBehaviour
{

    public int index;

    public Camera cam;

    public GameObject doorUIisUnder;

    public float offset;






    // Start is called before the first frame update
    void Start()
    {


        transform.GetChild(0).transform.position = cam.WorldToScreenPoint
        (new Vector2(doorUIisUnder.transform.position.x, doorUIisUnder.transform.position.y - offset));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
