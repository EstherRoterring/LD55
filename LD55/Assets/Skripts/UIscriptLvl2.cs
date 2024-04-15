using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIscriptLvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spaceBar;

    void Start()
    {
        if (ScenenWechsel.GameModeIsHard)
        {
            spaceBar.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceBar.SetActive(false);
        }
    }
}
