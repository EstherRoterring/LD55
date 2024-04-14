using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonewallDestruction : MonoBehaviour
{
    [SerializeField] Rigidbody2D stonewall;
    [SerializeField] Rigidbody2D brokenStonewall;
    [SerializeField] Rigidbody2D barrel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("other collider: " + collision.otherCollider);
        Debug.Log("collider:" + collision.collider);
    }
}
