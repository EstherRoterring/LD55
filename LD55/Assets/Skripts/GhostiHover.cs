using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostiHover : MonoBehaviour
{
    float startHeight;
    [SerializeField] float speed = 1f;
    [SerializeField] bool floatUP = false;
    [SerializeField] float wiggle = 1f; 
    void Start()
    {
        startHeight = this.gameObject.transform.position.y;
    }

    void Update()
    {
        if (floatUP)
        {
            this.gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (this.gameObject.transform.position.y >= wiggle + startHeight)
        {
            floatUP = false;
        }
        if (this.gameObject.transform.position.y <= startHeight - wiggle)
        {
            floatUP = true;
        }
    }
}
