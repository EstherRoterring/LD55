using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonewallDestruction : MonoBehaviour
{
    [SerializeField] GameObject stonewall;
    [SerializeField] GameObject brokenStonewall;
    [SerializeField] GameObject barrel;
    [SerializeField] GameObject chandelier;
    [SerializeField] GameObject explosion;
    bool alreadyTriggerd = false;
    void Start()
    {
        brokenStonewall.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {        
    }
    
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "projectile")
        {
            barrel.SetActive(false);
            stonewall.SetActive(false);
            brokenStonewall.SetActive(true);

        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "projectile")
        {
            barrel.SetActive(false);
            stonewall.SetActive(false);
            brokenStonewall.SetActive(true);
            if(collision.attachedRigidbody.name == "Chandelier" && !alreadyTriggerd)
            {
                chandelier.SetActive(false);
            }
            alreadyTriggerd = true;
        }
    }
}
