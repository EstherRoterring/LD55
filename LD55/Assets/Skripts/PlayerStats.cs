using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    // mana management
    public static int MaxMana = 100;
    public static int CurrentMana = 100;
    public static int[] manaLevels = new int[100];
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

    public static void fillMana()
    {
        for (int i = 0; i < manaLevels.Length; i++)
        {
            manaLevels[i] = 100;
        }
    }
}

