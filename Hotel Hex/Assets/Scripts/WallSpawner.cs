using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    public float blockAmount;
    float blockSize = 4f;

    float yRng;

    float initialPosition;

    public GameObject block;





    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.y;

        yRng = blockSize * blockAmount + initialPosition;

        for (float i = 0; i < initialPosition + yRng; i += blockSize)
        {
            print(i);
           GameObject newBlock = Instantiate(block, new UnityEngine.Vector2(transform.position.x, initialPosition), transform.rotation);
            newBlock.transform.position = new UnityEngine.Vector2(newBlock.transform.position.x, newBlock.transform.position.y - i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
