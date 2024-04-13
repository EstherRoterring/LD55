using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D myRB;

    [SerializeField] public float throwSpeed;
    [SerializeField] float gravity;

    // Start is called before the first frame update
    void Start()
    {
        //myRB = GetComponent<Rigidbody2D>();
        myRB.velocity = transform.forward * throwSpeed;
        myRB.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
