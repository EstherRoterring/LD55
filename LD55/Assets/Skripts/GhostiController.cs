using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostiController : MonoBehaviour
{

    public float speed = 2;
    public Transform target;
    private Vector3 rotation;

    public bool hochfliegen = false;
    public Rigidbody2D myRB;
    public float obereBorder;
    public float untereBorder;
    // Start is called before the first frame update
    void Start()
    {
        //hochfliegen = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //aktuelle Rotation bekommen -> standard
        rotation = transform.eulerAngles;


    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //umdrehen
        float a = transform.position.x;
        float b = target.position.x;
        float richtung = a - b;
        Debug.Log(richtung);

        if (richtung < 0)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
        }
        if (richtung > 0)
        {
            transform.eulerAngles = rotation;
        }





        //hoch runter Ghosti

        // if(hochfliegen){
        //     //hoch Bewegen
        //     //this.gameObject.transform.Translate(Vector3.down  * -speed * Time.deltaTime);
        //     myRB.velocity = new Vector2(0, speed);
        // }
        // else{
        //     //runter Bewegen
        //     myRB.velocity = new Vector2(0, -speed);
        // }

        // //umdrehen
        // if(myRB.position.y < untereBorder){
        //     hochfliegen = true;
        // }
        // if(myRB.position.y > obereBorder){
        //     hochfliegen = false;
        // }
    }
}
