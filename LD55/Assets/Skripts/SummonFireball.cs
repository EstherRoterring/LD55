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

    [SerializeField] Rigidbody2D rb;

    // mana management
    public static int MaxMana = 100;
    public static int CurrentMana = 100;
    [SerializeField] int manaConsumtion = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Summon();
    }

    void Summon()
    {
        if (Input.GetMouseButtonDown(0) && CurrentMana > 0)
        {
            CurrentMana -= manaConsumtion;

            /* float timer = 0;
            while (!Input.GetMouseButtonUp(0))
            {
                timer = timer + Time.deltaTime;
            } */
            Vector3 scale = rb.transform.localScale;
            GameObject ball = Instantiate(fireball, rb.transform.position + new Vector3(1.2f * Mathf.Cos(rb.transform.eulerAngles.y) - 0.2f, 1, 0) * scale.magnitude * 0.15f, rb.transform.rotation);
            ball.GetComponent<Fireball>().playerRB = rb;
            ball.GetComponent<Fireball>().player = this.gameObject;
            // ball.GetComponent<Fireball>().strenth = Mathf.Min(timer / 3f * 100f, 100);
            ball.GetComponent<Fireball>().strenth = 100;
        }
    }
}
