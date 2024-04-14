using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class Fireball : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject explosion;
    [SerializeField] Vector2 throwSpeed;
    [SerializeField] AudioClip throwAudio;
    public float strenth;
    float chargeTime;
    bool done;
    Vector3 initialScale;
    float throwScale;
    float chargeScale;

    //merkt sich ob der ball schon geworfen wurde
    bool isThrown;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        chargeTime = 0;
        done = false;
        initialScale = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion();
        if (strenth <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        strenth = strenth - 5;

        if (collision.collider.name == "Trigger")
        {
            this.GetComponent<Collider2D>().sharedMaterial = collision.collider.sharedMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Fireball mit Player mitlaufen
        if (!isThrown)
        {
            transform.Translate(Vector2.right * PlayerController.richtung * PlayerController.speed * Time.deltaTime);
        }

        //transform.rotation = Quaternion.LookRotation(myRB.velocity);
        chargeTime += Time.deltaTime;
        chargeScale = Mathf.Min(0.4f + chargeTime * 2, 2f);
        if (!done)
        {
            this.gameObject.transform.localScale = initialScale * chargeScale;
            //this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, Mathf.Min(chargeTime, 1f));
        }

        if (Input.GetMouseButtonUp(0) && !done)
        {
            //Fireball werfen = merken
            isThrown = true;

            strenth = Mathf.Min(chargeTime * 1, 1);
            rb.bodyType = RigidbodyType2D.Dynamic;
            Vector2 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 ballPosi = rb.position;
            rb.velocity = Vector2.Scale((mousePosi - ballPosi).normalized, throwSpeed) * strenth;
            done = true;
            this.gameObject.GetComponent<AudioSource>().clip = throwAudio;
            this.gameObject.GetComponent<AudioSource>().Play();
            throwScale = chargeScale;
        }
    }

    void Explosion()
    {
        GameObject explo = Instantiate(explosion, rb.transform.position, rb.transform.rotation);
        explo.transform.localScale *= throwScale;
    }

}
