using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    //Variablen fuers Movement
    public float speed = 5;
    public float jumpforce = 7;
    public Rigidbody2D rb;
    public Animator anim;
    public bool lookingRight = true;
    public bool isGrounded;

    //Keys aendern
    public KeyCode jump = KeyCode.Space;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(jump)){
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            //                                  impulshaft von unten nach oben
        }
        
    }

    void FixedUpdate()
    {
        //Movement 
        //(-1/1)
        float richtung = Input.GetAxis("Horizontal");

        //geschwindigkeit
        transform.Translate(Vector2.right * richtung * speed * Time.deltaTime);


    }

    //zum umdrehen des players
    public void Flip(){
        //Blickrichtung aendern
        lookingRight = !lookingRight;
        

    }

    //test ob auf Boden -> anti Flug Programm :)
    public void OnCollisionEnter2D(){
        //if(Collision.gameObject.tag == "ground"){

    }


}
