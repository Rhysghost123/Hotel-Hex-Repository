using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TotaKeys : MonoBehaviour
{


    TMPro.TMP_Text progressText;




    // Start is called before the first frame update
    void Start()
    {
        progressText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        progressText.text = "Total Keys Accquired: " + GameManager.instance.worldScore.ToString() + "/10";
    }
}
