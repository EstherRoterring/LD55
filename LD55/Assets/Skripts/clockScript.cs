using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class clockScript : MonoBehaviour
{

    //stopuhr
    public static float currentTime;
    public static bool clockStarted = false;
    [SerializeField] TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        if (!ScenenWechsel.GameModeIsHard)
        {
            timeText.gameObject.SetActive(false);
        }

        //currentTime = 0;
        clockStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (clockStarted)
        {
            currentTime += Time.deltaTime;
        }
        timeText.text = "Time: " + currentTime.ToString("0.0");
    }
}
