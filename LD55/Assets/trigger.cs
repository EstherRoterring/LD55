using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update
    // public open_close open_close;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Fireball(Clone)")
        {
            Debug.Log("Door triger send");
            open_close.OpenStatus = true;
        }
    }
}
