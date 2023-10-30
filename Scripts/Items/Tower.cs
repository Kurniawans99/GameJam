using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject visualTree;
    public static Tower Instance { get; private set; }
    public  event EventHandler<OnTreeHitEventArgs> OnTreeHit;
    public event EventHandler OnTreeDeath;
    public class OnTreeHitEventArgs : EventArgs
    {
        public float currentHealth;
    }
    [SerializeField] private float MaxHealth = 500f; 
    [SerializeField] public float health = 500f;

    public static event EventHandler OnHealthChanged;

    private void Awake()
    {
        Instance = this;
    }
    public void TakenDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnTreeDeath?.Invoke(this, EventArgs.Empty);
            Destroy(visualTree);
            Destroy(gameObject);
        }
        OnTreeHit?.Invoke(this, new OnTreeHitEventArgs { currentHealth = health });
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
        OnTreeHit?.Invoke(this, new OnTreeHitEventArgs { currentHealth = health });

    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

}
