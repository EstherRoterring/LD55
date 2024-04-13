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
        myRB.velocity = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - myRB.position).normalized * throwSpeed * 0.1f;
        myRB.gravityScale = gravity;
        myRB.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
