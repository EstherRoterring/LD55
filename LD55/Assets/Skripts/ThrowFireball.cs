using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class SummonFirball : MonoBehaviour
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
        ThrowFireball();
    }

    void ThrowFireball()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireball, rb.transform.position + new Vector3(0, 1, 0), rb.transform.rotation);
        }
    }
}
