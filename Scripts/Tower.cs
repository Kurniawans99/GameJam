using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static Tower Instance { get; private set; }
    [SerializeField] private float health = 500f;
    private void Awake()
    {
        Instance = this;
    }

    public void TakenDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
