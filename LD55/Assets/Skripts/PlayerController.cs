using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //Variablen fuers Movement
    public static float speed = 20;
    public float jumpforce = 7;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isGrounded;
    public float ClimbSpeed = 1;
    public static float richtung;
    [SerializeField] float gravityScale = 4;

    //Keys aendern
    public KeyCode jump = KeyCode.Space;
    public KeyCode up = KeyCode.W;

    //Variablen fuer Animation
    //isRunning = laufanimation an machen
    public bool isRunning;
    private Vector3 rotation;

    //Remember todesort/lvl
    public static int restartPoint;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //aktuelle Rotation bekommen -> standard
        rotation = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {

        //Springen
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            //                                  impulshaft von unten nach oben
            isGrounded = false;
        }

    }

    void FixedUpdate()
    {
        //Movement rechts - links 
        //(-1/1)
        richtung = Input.GetAxis("Horizontal");

        //laufanimation 
        if (richtung != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //undrehen
        if (richtung < 0)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
            //laufen
            transform.Translate(Vector2.right * -richtung * speed * Time.deltaTime);


        }
        if (richtung > 0)
        {
            transform.eulerAngles = rotation;
            //laufen
            transform.Translate(Vector2.right * richtung * speed * Time.deltaTime);
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Logik f�r interaktion mit Ghostis
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy detected");
            restartPoint = SceneManager.GetActiveScene().buildIndex;
            Destroy(gameObject);
            //Spawn dead body?
            new WaitForSeconds(1.5f);
            SceneManager.LoadScene("StandardDeath");
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Leiterbewegung
        if(collision.gameObject.tag == "Lather" && Input.GetKey(up))
        {
            transform.Translate(Vector2.up * ClimbSpeed * Time.deltaTime);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravityScale;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lather" && Input.GetKey(up))
        {
            rb.gravityScale = gravityScale;
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);

        //test ob auf Boden -> anti Flug Programm :)
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        //next Room
        if (collision.gameObject.tag == "openDoor")
        {
            //scenenwechsel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //Tode/Death
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Enemy detected");
            restartPoint = SceneManager.GetActiveScene().buildIndex;
            Destroy(gameObject);
            //Spawn dead body?
            new WaitForSeconds(1.5f);
            SceneManager.LoadScene("StandardDeath");

        }
        if (collision.collider.tag == "projectile")
        {
            restartPoint = SceneManager.GetActiveScene().buildIndex;
            Destroy(gameObject);
            //Spawn dead body?
            new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Suicide");
            Debug.Log("end");
        }
    }



}