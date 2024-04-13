using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class SummonFireball : MonoBehaviour
{

    [SerializeField] GameObject fireball;

    [SerializeField] Rigidbody2D rb;

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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(fireball, rb.transform.position + new Vector3(0, 1, 0), rb.transform.rotation);
            ball.GetComponent<Fireball>().strenth = 66;
        }
    }
}
