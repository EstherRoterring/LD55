using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class endScreen : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (ScenenWechsel.GameModeIsHard)
        {
            text.text = "You finnished in " + clockScript.currentTime.ToString("0.0") + "s\n Good job!";

        }
        else
        {
            text.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
