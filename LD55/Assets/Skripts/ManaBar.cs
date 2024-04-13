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
        manaBar.maxValue = SummonFireball.MaxMana;
        manaBar.value = SummonFireball.CurrentMana;
    }
    private void Update()
    {
        manaBar.value = SummonFireball.CurrentMana;
    }

    public void SetHealth(int hp)
    {
        manaBar.value = hp;
    }
}
