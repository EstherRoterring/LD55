using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cinemachine.Utility;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class SummonFireball : MonoBehaviour
{

    [SerializeField] GameObject fireball;

    Rigidbody2D rb;


    [SerializeField] int manaConsumtion = 10;
    float chargeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Summon();
    }

    void Summon()
    {
        if (Input.GetMouseButtonDown(0) && playerStats.CurrentMana > 0)
        {
            Vector3 scale = rb.transform.localScale;
            GameObject ball = Instantiate(fireball, rb.transform.position + new Vector3(2f * (Mathf.Cos(rb.transform.eulerAngles.y) - 0.2f), 1.2f, 0) * scale.magnitude * 0.15f, rb.transform.rotation);
            //ball.GetComponent<Fireball>().player = this.gameObject;
            ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            playerStats.CurrentMana -= manaConsumtion;
            //ball.GetComponent<SpriteRenderer>().material.color = new Color(1f,1f,1f,0f);
        }

    }
}
