using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "manaPotion")
        {
            CurrentMana = MaxMana;
            collision.collider.gameObject.SetActive(false);
        }
    }
}
    
