using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D myRB;
    public Rigidbody2D playerRB;
    public GameObject player;

    [SerializeField] GameObject explosion;

    [SerializeField] public Vector2 throwSpeed;
    [SerializeField] float gravity;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip burst;

    public float strenth;

    // Start is called before the first frame update
    void Start()
    {
        // myRB.velocity = Vector2.Scale((new Vector2(Input.mousePosition.x, Input.mousePosition.y) - myRB.position).normalized, new Vector2(Mathf.Cos(myRB.transform.eulerAngles.y), 1)) * throwSpeed * 0.1f;
        // myRB.velocity = (new Vector2(Input.mousePosition.x + playerRB.position.x, Input.mousePosition.y) - myRB.position) * throwSpeed * 0.01f;
        Vector2 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 ballPosi = myRB.position;

        // int scale = ((mousePosi - ballPosi).y < 0) ? 0 : 1; // hier um beschleuningung wenn maus unter dem kopf aus zu stellen
        int scale = 1;

        myRB.velocity = Vector2.Scale((mousePosi - ballPosi), new Vector2(1, scale)).normalized * throwSpeed;

        myRB.gravityScale = gravity;
        myRB.bodyType = RigidbodyType2D.Dynamic;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hallooo ich ibn ni der colisiion detection uns od danke");
        Explosion();
        if (strenth <= 0)
        {
            Debug.Log("I habs in die if schleife gschafft");
            Destroy(this.gameObject);
            return;
        }
        strenth = strenth - 50;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(myRB.velocity);
    }

    void Explosion()
    {
        Instantiate(explosion, myRB.transform.position, myRB.transform.rotation);
        Debug.Log("halloo ich bin unter der Explison aber noch drinne");
    }

}
