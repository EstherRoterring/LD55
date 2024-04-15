using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_close : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool OpenStatus = false;
    [SerializeField] Collider2D DoorCollider;
    [SerializeField] SpriteRenderer DoorSprite;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            DoorCollider.enabled = false;
            DoorSprite.enabled = false;
        }
        
    }
}
