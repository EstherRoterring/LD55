using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingChandelier : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Untagged";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "projectile")
        {
            hinge.enabled = false;
            this.gameObject.tag = "projectile";
            Debug.Log("Chandelier detected collision");
        }
        if(collision.collider.tag == "ground")
        {
            this.gameObject.tag = "Untagged";
        }

    }
 
}
