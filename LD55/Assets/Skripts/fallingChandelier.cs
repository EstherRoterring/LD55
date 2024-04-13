using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingChandelier : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D myRB;
    [SerializeField] float newGravity;
    void Start()
    {
        myRB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "projectile")
        {
            myRB.gravityScale = newGravity;
            Debug.Log("Chandelier detected collision");
        }

    }
 
}
