using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] float throwSpeed;

    [SerializeField] float gravityScale;

    [SerializeField] GameObject Burst;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * throwSpeed;
        rb.gravityScale = gravityScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Burst, transform.position, transform.rotation);
        // hier code der ausgführt werden soll zb für enemys oder tragets
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
