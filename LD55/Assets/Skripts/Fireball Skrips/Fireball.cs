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
    public float strenth;
    float chargeTime;
    bool done;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        chargeTime = 0;
        done = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(myRB.velocity);
        chargeTime += Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && !done)
        {
            strenth = Mathf.Min(chargeTime * 10, 10);
            rb.bodyType = RigidbodyType2D.Dynamic;
            Vector2 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 ballPosi = rb.position;
            rb.velocity = Vector2.Scale((mousePosi - ballPosi).normalized, throwSpeed) * strenth * 0.15f;
            done = true;
        }
    }

    void Explosion()
    {
        Instantiate(explosion, rb.transform.position, rb.transform.rotation);
    }

}
