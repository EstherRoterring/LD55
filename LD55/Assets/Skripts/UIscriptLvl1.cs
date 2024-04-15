using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject aButton;
    [SerializeField] GameObject dButton;
    void Start()
    {
        if (ScenenWechsel.GameModeIsHard)
        {
            aButton.SetActive(false);
            dButton.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            aButton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dButton.SetActive(false);
        }
        
    }
}
