using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public event EventHandler OnPlayerShoot;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private Transform projectile;
    public static Bow Instance { get; private set; }
    public float fireRate;
    public float fireRateMax = 0.3f;
    public float speed = 25f;
    public float damage = 10f;
    public float burnDamage = 2f;
    public float burnDuration = 2f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        fireRate += Time.deltaTime;
    }

    public void Fire()
    {
        if (fireRate > fireRateMax)
        {
            OnPlayerShoot?.Invoke(this, EventArgs.Empty);

            Transform arrow = Instantiate(projectile, projectileSpawn);
            arrow.SetParent(null);
            if (PlayerSkill.Instance.IsDoubleArrow())
            {
                StartCoroutine(PlayerSkill.Instance.DoubleArrow(transform.position, projectile));
            }
            fireRate = 0f;
        }

    }
}
