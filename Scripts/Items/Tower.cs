using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 500f; 
    [SerializeField] private float health = 500f;

    public static event EventHandler OnHealthChanged;


    public void TakenDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        OnHealthChanged?.Invoke(this, EventArgs.Empty);

    }

    public void Heal(int amount)
    {
        if(health + amount >= MaxHealth)
        {
            health = MaxHealth;
        }
        else
        {
            health += amount;
        }
        OnHealthChanged?.Invoke(this, EventArgs.Empty);

    }

}
