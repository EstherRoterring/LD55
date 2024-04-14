using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    // mana management
    public static int MaxMana = 100;
    public static int CurrentMana = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "manaPotion")
        {
            CurrentMana = MaxMana;
            collision.collider.gameObject.SetActive(false);
        }
    }
}
    
