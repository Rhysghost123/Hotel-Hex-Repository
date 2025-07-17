using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TotaKeys : MonoBehaviour
{


    TMPro.TMP_Text progressText;

    public int index;




    // Start is called before the first frame update
    void Start()
    {
        progressText = GetComponent<TMPro.TMP_Text>();

        switch (index)
        {
            case 0:
                progressText.text = "Total Keys Accquired: " + GameManager.instance.worldScore.ToString() + "/20";
                break;

            case 1:
                progressText.text = "Keys Accquired: " + GameManager.instance.leveloneScore.ToString() + "/10";
                break;

            case 2:
                progressText.text = "Total Keys Accquired: " + GameManager.instance.leveltwoScore.ToString() + "/10";
                break;

            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
