using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider manaBar;
    public int playerMana;

    private void Start()
    {
        manaBar = GetComponent<Slider>();
        manaBar.maxValue = PlayerStats.MaxMana;
        manaBar.value = PlayerStats.CurrentMana;
    }
    private void Update()
    {
        manaBar.value = PlayerStats.CurrentMana;
    }

    public void SetHealth(int mana)
    {
        manaBar.value = mana;
    }
}
