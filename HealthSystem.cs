using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;

    private int HPMax;
    private int currentHP;

    public HealthSystem(int HP)
    {
        HPMax = HP;
        currentHP = HPMax;

    }
    public void DamageAmount(int hitDamage)
    {
        currentHP -= hitDamage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }

        OnHealthChanged.Invoke(this, EventArgs.Empty);
        
    }

    public float GetCurrentHealth()
    {
        return (float) currentHP / HPMax;
    }

    public int GetHP()
    {
        return currentHP;
    }
}
