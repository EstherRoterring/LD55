using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FassController : MonoBehaviour
{

    public GameObject wirdZerstoert;
    public GameObject explosion;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);

        if (collision.collider.tag == "brennbar")
        {
            wirdZerstoert = collision.gameObject;
            //Destroy(collision.gameObject);
            Debug.Log("Wand weg");
        }
         if (collision.collider.tag == "projectile")
        {
            Destroy(gameObject);
            GameObject explo = Instantiate(explosion, rb.transform.position, rb.transform.rotation);
            explo.transform.localScale *= 10 ;
            Destroy(wirdZerstoert);
            //Truemmer spawnen waer noch gut
        }

    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.attachedRigidbody.tag == "projectile")
    //     {
    //         Destroy(gameObject);
    //         GameObject explo = Instantiate(explosion, rb.transform.position, rb.transform.rotation);
    //         explo.transform.localScale *= 10 ;
    //         Destroy(wirdZerstoert);
    //         //Truemmer spawnen waer noch gut
    //     }
    // }
}
