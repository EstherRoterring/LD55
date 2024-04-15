using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RButton : MonoBehaviour
{
    [SerializeField] GameObject rButton;
    // Start is called before the first frame update
    void Start()
    {
        rButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.CurrentMana < 10)
        {
            rButton.SetActive(true);
        }
        else
        {
            rButton.SetActive(false);
        }
    }
}
