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
    public bool isGrounded;

    //Keys aendern
    public KeyCode jump = KeyCode.Space;

    //Variablen fuer Animation
    //isRunning = laufanimation an machen
    public bool isRunning;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //Springen
        if(Input.GetKeyDown(jump) && isGrounded){
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            //                                  impulshaft von unten nach oben
            isGrounded = false;
        }
        
    }

    void FixedUpdate()
    {
        //Movement rechts - links 
        //(-1/1)
        float richtung = Input.GetAxis("Horizontal");
        //geschwindigkeit
        transform.Translate(Vector2.right * richtung * speed * Time.deltaTime);

        //laufanimation 
        if(richtung != 0){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }

    }


    //test ob auf Boden -> anti Flug Programm :)
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ground"){
            isGrounded = true;
        }
    }


}
