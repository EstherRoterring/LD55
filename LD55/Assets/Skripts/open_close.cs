using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_close : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static bool OpenStatus = false;
    [SerializeField] Collider2D DoorCollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OpenStatus)
        {
            DoorCollider.enabled = false;
            Debug.Log("Door opened");
        }
        else DoorCollider.enabled = true;
    }
}
