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

        //Debug.Log(this.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "manaPotion")
        {
            CurrentMana = MaxMana;
            collision.gameObject.SetActive(false);
        }


    }

    public static void fillallMana()
    {
        for (int i = 0; i < manaLevels.Length; i++)
        {
            manaLevels[i] = MaxMana;
        }
    }

    public static void saveCurrentMana(int level)
    {
        manaLevels[level] = CurrentMana;
    }
    public static void loadMana(int level)
    {
        CurrentMana = manaLevels[level];
    }

    public static void fillCurrentMana()
    {
        CurrentMana = MaxMana;
    }
}

