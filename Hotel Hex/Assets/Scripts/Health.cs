using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxhealth;
    public float minhealth;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 3;
        minhealth = maxhealth;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D enemy)
    {
        minhealth -= 1;
        print("player took Damage!");
    }
    private void Update()
    {
        if (minhealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
